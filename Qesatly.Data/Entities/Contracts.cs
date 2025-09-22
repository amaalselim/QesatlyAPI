using System.ComponentModel.DataAnnotations.Schema;

namespace Qesatly.Data.Entities
{
    public class Contracts
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DownPayment { get; set; }
        public decimal insertRate { get; set; }
        public int InstallmentCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Products")]
        public int? productId { get; set; }
        public virtual Products? Products { get; set; }
        [ForeignKey("Clients")]
        public int? clientId { get; set; }
        public virtual Clients? Clients { get; set; }

    }
}
