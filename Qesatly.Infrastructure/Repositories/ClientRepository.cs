using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Qesatly.Core.Bases;
using Qesatly.Data.Entities;
using Qesatly.Data.Enums;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Infrastructure.Context;
using Qesatly.Service.Abstracts;
using Qesatly.Service.DTO;

namespace Qesatly.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly ResponseHandler _responseHandler;

        public ClientRepository(ApplicationDBContext context, IMapper mapper, IImageService imageservice,
            ResponseHandler responseHandler)
        {
            _context = context;
            _mapper = mapper;
            _imageService = imageservice;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> AddAsync(AddClientDto client)
        {
            var clientmapper = _mapper.Map<Clients>(client);

            if (client.Cardphoto != null)
            {
                var path = @"Images/Clients/Card/";
                clientmapper.Cardphoto = await _imageService.SaveFileAsync(client.Cardphoto, path);
            }
            if (client.Isguarantor)
            {
                var path = @"Images/Clients/guarantorCard/";
                if (client.guarantorCardphoto != null)
                {
                    clientmapper.guarantorCardphoto = await _imageService.SaveFileAsync(client.guarantorCardphoto, path);
                }
            }
            await _context.clients.AddAsync(clientmapper);
            await _context.SaveChangesAsync();
            return _responseHandler.Created<string>("Client added successfully", $" ClientId : {clientmapper.Id}");

        }
        public async Task<Response<IEnumerable<GetClientsDto>>> GetAllAsync()
        {
            var installments = await _context.installments
                .Include(i => i.Contracts)
                .ThenInclude(c => c.Clients)
                .Include(i => i.Contracts)
                .ThenInclude(c => c.Products)
            .ToListAsync();

            var clientsDto = installments
                .GroupBy(i => i.ContractId)
                .Select(c => new GetClientsDto
                {
                    Name = c.First().Contracts.Clients.Name,
                    productName = c.First().Contracts.Products.Name,
                    paidInstallments = $"{c.Count(i => i.IsPaid)}/{c.First().Contracts.InstallmentCount}",
                    ContractStatus = c.All(i => i.IsPaid) ? ContractStatus.FullyPaid.ToString() : ContractStatus.Active.ToString()

                });

            return _responseHandler.Success<IEnumerable<GetClientsDto>>(clientsDto);
        }
    }
}
