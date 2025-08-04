
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = OMAR; Database = LibrarySystemDb; TrustServerCertificate = True; Trusted_Connection = True");
        }
        public DbSet<Book> Stock { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MakeSale> Sales { get; set; }

    }
}
