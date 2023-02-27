using Lb1.DB.Entites.ATM;
using Lb1.DB.Entites.Bank;
using Lb1.DB.Entites.BankE.CreditE;
using Lb1.DB.Entites.ClientE;
using Microsoft.EntityFrameworkCore;

namespace Lb1.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Citizenship> Citizenships { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<DepositPlane> DepositPlanes { get; set; }
        public DbSet<DepositList> DepositLists { get; set; }
        public DbSet<CreditPlane> CreditPlanes { get; set; }
        public DbSet<CreditList> CreditLists { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
