using Microsoft.EntityFrameworkCore;
using SalesAdminPortalAPI.Models.Entities;

namespace SalesAdminPortalAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        // {

        // }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
          
        }
        public DbSet<Salesman> Salesmans { get; set; }
    }
}
