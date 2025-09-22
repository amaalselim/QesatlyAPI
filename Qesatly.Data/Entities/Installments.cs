using System.ComponentModel.DataAnnotations.Schema;

namespace Qesatly.Data.Entities
{
    public class Installments
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        [ForeignKey("Contracts")]
        public int? ContractId { get; set; }
        public virtual Contracts? Contracts { get; set; }

    }
}
