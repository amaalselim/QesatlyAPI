using AutoMapper;
using Qesatly.Core.Bases;
using Qesatly.Data.Entities;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Infrastructure.Context;
using Qesatly.Service.DTO;

namespace Qesatly.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ContractRepository(ApplicationDBContext context, IMapper mapper, ResponseHandler responseHandler)
        {
            _context = context;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<Response<string>> AddAsync(AddProductDto product)
        {
            var productmapper = _mapper.Map<Products>(product);
            productmapper.clientId = product.clientId;
            await _context.products.AddAsync(productmapper);
            await _context.SaveChangesAsync();

            decimal remaining = productmapper.Price - product.DownPayment;
            decimal rate = product.insertRate / 100m;
            decimal afterInterest = remaining * (1 + rate);
            decimal installmentValue = afterInterest / product.InstallmentCount;

            DateTime createdAt = product.CreatedAt;
            DateTime startDate = product.StartDate;

            Contracts contracts = new Contracts
            {
                productId = productmapper.Id,
                clientId = product.clientId,
                DownPayment = product.DownPayment,
                insertRate = product.insertRate,
                InstallmentCount = product.InstallmentCount,
                StartDate = startDate,
                EndDate = startDate.AddMonths(product.InstallmentCount),
                CreatedAt = createdAt,
                TotalPrice = afterInterest,
                InstallmentValue = installmentValue
            };

            await _context.contracts.AddAsync(contracts);
            await _context.SaveChangesAsync();

            var installments = GenerateInstallments(contracts);
            await _context.installments.AddRangeAsync(installments);
            await _context.SaveChangesAsync();

            return _responseHandler.Created<string>("Product added successfully", null);
        }

        private List<Installments> GenerateInstallments(Contracts contracts)
        {
            var Installments = new List<Installments>();
            for (int i = 0; i < contracts.InstallmentCount; i++)
            {
                Installments.Add(new Installments
                {
                    ContractId = contracts.Id,
                    Amount = contracts.InstallmentValue,
                    DueDate = contracts.StartDate.AddMonths(i),
                    IsPaid = false
                });
            }
            return Installments;
        }
    }
}
