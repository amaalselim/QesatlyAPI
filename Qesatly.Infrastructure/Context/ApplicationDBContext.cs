using Microsoft.EntityFrameworkCore;
using Qesatly.Data.Entities;

namespace Qesatly.Infrastructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Clients> clients { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Contracts> contracts { get; set; }
        public DbSet<Installments> installments { get; set; }
    }
}
