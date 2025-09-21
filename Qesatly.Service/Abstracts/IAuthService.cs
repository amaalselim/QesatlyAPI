using Qesatly.Core.Bases;
using Qesatly.Service.DTO;

namespace Qesatly.Service.Abstracts
{
    public interface IAuthService
    {
        Task<Response<string>> LoginAsync(LoginDto loginDto);

    }
}
