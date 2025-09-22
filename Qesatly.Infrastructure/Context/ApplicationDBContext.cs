using Microsoft.EntityFrameworkCore;

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
    }
}
