using Lb1.DB.Entites;
using Microsoft.EntityFrameworkCore;

namespace Lb1.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Citizenship> Citizenships { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Town> Towns { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
