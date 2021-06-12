using Microsoft.EntityFrameworkCore;
using RepositoryPatternNet5Api.Models;

namespace ApiDbContext.Data
{
	public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Supplier> Supplier { get; set; }
    }
}
