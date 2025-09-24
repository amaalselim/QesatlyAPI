using Qesatly.Core.Bases;
using Qesatly.Service.DTO;

namespace Qesatly.Infrastructure.Abstracts
{
    public interface IClientRepository
    {
        Task<Response<string>> AddAsync(AddClientDto client);
        Task<Response<IEnumerable<GetClientsDto>>> GetAllAsync(string? search = null);
        Task<Response<dashboardDto>> GetDashboardDataAsync();
    }
}
