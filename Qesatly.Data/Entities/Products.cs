using System.ComponentModel.DataAnnotations.Schema;

namespace Qesatly.Data.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(Products))]
        public int? clientId { get; set; }
        public virtual Clients? Clients { get; set; }
    }
}
