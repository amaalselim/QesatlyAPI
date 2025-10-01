using Microsoft.AspNetCore.Mvc;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Service.DTO;

namespace QesatlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        private readonly IInstallmentRepository _installmentRepository;

        public InstallmentsController(IInstallmentRepository installmentRepository)
        {
            _installmentRepository = installmentRepository;
        }
        [HttpGet("get-all-installments")]
        public async Task<IActionResult> GetAllInstallments()
        {
            var result = await _installmentRepository.GetAllInstallmetns();
            return StatusCode((int)result.StatusCode, result);
        }
        [HttpGet("get-installment-by-id/{id}")]
        public async Task<IActionResult> GetInstallmentById(int id)
        {
            var result = await _installmentRepository.GetInstallmentById(id);
            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost("record-payment/{id}")]
        public async Task<IActionResult> RecordPayment(int id, [FromBody] RecordPaymentDto recordPaymentDto)
        {
            var result = await _installmentRepository.RecordPayment(id, recordPaymentDto);
            return StatusCode((int)result.StatusCode, result);
        }

    }
}
