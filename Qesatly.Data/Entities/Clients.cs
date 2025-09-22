namespace Qesatly.Data.Entities
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string NationalNumber { get; set; }
        public string Address { get; set; }
        public string Cardphoto { get; set; }
        public bool Isguarantor { get; set; } = false;
        // if Isguarantor is true, the following fields will be filled
        public string? guarantorName { get; set; }
        public string? guarantorPhone { get; set; }
        public string? guarantorCardphoto { get; set; }
    }
}
