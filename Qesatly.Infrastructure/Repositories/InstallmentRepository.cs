using Microsoft.EntityFrameworkCore;
using Qesatly.Core.Bases;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Infrastructure.Context;
using Qesatly.Service.DTO;

namespace Qesatly.Infrastructure.Repositories
{
    public class InstallmentRepository : IInstallmentRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ResponseHandler _responseHandler;

        public InstallmentRepository(ApplicationDBContext context, ResponseHandler responseHandler)
        {
            _context = context;
            _responseHandler = responseHandler;
        }
        public async Task<Response<IEnumerable<GetAllInstallmentsDto>>> GetAllInstallmetns()
        {
            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var installments = await _context.installments
               .Include(i => i.Contracts)
                       .ThenInclude(c => c.Clients)
               .Include(i => i.Contracts)
                        .ThenInclude(c => c.Products)
               .Where(i => i.DueDate >= startOfMonth && i.DueDate <= endOfMonth)
               .ToListAsync();

            var installmentDtos = installments.Select(i => new GetAllInstallmentsDto
            {
                Id = i.Id,
                DueDate = i.DueDate,
                InstallmentValue = i.Amount,
                IsPaid = i.IsPaid ? "Paid" : "Not Paid",
                clientName = i.Contracts.Clients.Name,
                productName = i.Contracts.Products.Name
            });
            return _responseHandler.Success<IEnumerable<GetAllInstallmentsDto>>(installmentDtos);

        }

        public async Task<Response<GetInstallmentByIdDto>> GetInstallmentById(int id)
        {
            var installment = await _context.installments
                .Include(i => i.Contracts)
                        .ThenInclude(c => c.Clients)
                .Include(i => i.Contracts)
                         .ThenInclude(c => c.Products)
                .FirstOrDefaultAsync(i => i.Id == id);

            var paidAmount = _context.installments
                .Where(i => i.ContractId == installment.ContractId && i.IsPaid)
                .Sum(i => i.Amount);


            if (installment == null)
                return _responseHandler.NotFound<GetInstallmentByIdDto>();

            var installmentDto = new GetInstallmentByIdDto
            {
                Id = installment.Id,
                clientName = installment.Contracts.Clients.Name,
                productName = installment.Contracts.Products.Name,
                phoneNumber = installment.Contracts.Clients.Phone,
                PaidAmount = paidAmount,
                DueAmount = installment.Amount,
                Balance = installment.Contracts.TotalPrice - paidAmount
            };
            return _responseHandler.Success<GetInstallmentByIdDto>(installmentDto);
        }

        public async Task<Response<string>> RecordPayment(int id, RecordPaymentDto recordPaymentDto)
        {
            var installment = await _context.installments.FirstOrDefaultAsync(i => i.Id == id);
            if (installment == null)
                return _responseHandler.NotFound<string>("Installment not found");

            if (installment.IsPaid)
                return _responseHandler.BadRequest<string>("Installment is already paid");

            installment.Amount = recordPaymentDto.AmountPaid;
            installment.IsPaid = true;
            installment.PaymentDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return _responseHandler.Success<string>("Payment recorded successfully");
        }
    }
}
