using Qesatly.Core.Bases;
using Qesatly.Service.DTO;

namespace Qesatly.Infrastructure.Abstracts
{
    public interface IContractRepository
    {
        Task<Response<string>> AddAsync(AddProductDto product);
    }
}
