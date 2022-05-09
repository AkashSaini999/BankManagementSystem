using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankManagementSystem.Data
{
    public class BankDbContext:DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
: base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Customer> customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
