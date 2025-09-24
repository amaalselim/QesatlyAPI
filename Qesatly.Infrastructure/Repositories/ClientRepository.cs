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
            var existingClient = await _context.clients
                 .FirstOrDefaultAsync(c => c.NationalNumber == client.NationalNumber);

            Clients clientmapper;
            if (existingClient != null)
            {
                clientmapper = existingClient;
            }
            else
            {
                clientmapper = _mapper.Map<Clients>(client);
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
            }
            return _responseHandler.Created<string>("Client added successfully",
                $" ClientId : {clientmapper.Id}");

        }
        public async Task<Response<IEnumerable<GetClientsDto>>> GetAllAsync(string? search = null)
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

            if (!string.IsNullOrEmpty(search))
            {
                clientsDto = clientsDto.Where(x =>
                    x.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    x.productName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            return _responseHandler.Success<IEnumerable<GetClientsDto>>(clientsDto);
        }

        public async Task<Response<dashboardDto>> GetDashboardDataAsync()
        {
            var totalClients = await _context.clients.CountAsync();
            var totalProducts = await _context.products.CountAsync();

            var installments = await _context.installments
                 .GroupBy(i => i.ContractId)
                 .ToListAsync();
            var completed = installments.Count(g => g.All(i => i.IsPaid));
            var active = installments.Count(g => g.Any(i => !i.IsPaid));

            var dashboardData = new dashboardDto
            {
                totalClients = totalClients,
                totalProducts = totalProducts,
                completedInstallments = completed,
                activeInstallments = active
            };

            return _responseHandler.Success<dashboardDto>(dashboardData);
        }

    }

}
