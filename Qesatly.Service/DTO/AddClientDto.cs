using Microsoft.AspNetCore.Http;

namespace Qesatly.Service.DTO
{
    public class AddClientDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int NationalNumber { get; set; }
        public string Address { get; set; }
        public IFormFile Cardphoto { get; set; }
        public bool Isguarantor { get; set; } = false;
        public string? guarantorName { get; set; }
        public string? guarantorPhone { get; set; }
        public int? guarantorNationalNumber { get; set; }
        public string? guarantorAddress { get; set; }
        public IFormFile? guarantorCardphoto { get; set; }
    }
}
