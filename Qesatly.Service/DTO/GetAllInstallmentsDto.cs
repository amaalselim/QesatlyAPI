namespace Qesatly.Service.DTO
{
    public class GetAllInstallmentsDto
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public string clientName { get; set; }
        public decimal InstallmentValue { get; set; }
        public DateTime DueDate { get; set; }
        public string IsPaid { get; set; }

    }
}
