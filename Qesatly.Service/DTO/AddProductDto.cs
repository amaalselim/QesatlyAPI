namespace Qesatly.Service.DTO
{
    public class AddProductDto
    {
        public int clientId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DownPayment { get; set; }
        public decimal insertRate { get; set; }
        public int InstallmentCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
