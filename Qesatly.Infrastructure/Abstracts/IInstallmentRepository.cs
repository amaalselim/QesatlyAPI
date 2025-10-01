using Qesatly.Core.Bases;
using Qesatly.Service.DTO;

namespace Qesatly.Infrastructure.Abstracts
{
    public interface IInstallmentRepository
    {
        Task<Response<IEnumerable<GetAllInstallmentsDto>>> GetAllInstallmetns();
        Task<Response<GetInstallmentByIdDto>> GetInstallmentById(int id);
        Task<Response<string>> RecordPayment(int id, RecordPaymentDto recordPaymentDto);
    }
}
