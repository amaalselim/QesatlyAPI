namespace Qesatly.Service.DTO
{
    public class GetInstallmentByIdDto
    {
        public int Id { get; set; }
        public string clientName { get; set; }
        public string phoneNumber { get; set; }
        public string productName { get; set; }
        public decimal InstallmentValue { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
