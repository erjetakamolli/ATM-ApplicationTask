using Microsoft.EntityFrameworkCore;
using ATM_ApplicationTask.Models;

namespace ATM_AplicationTask.Data
{ 
    public class ATMDbContext : DbContext
    {
               
        public ATMDbContext(DbContextOptions<ATMDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.CurrentAccountBalance)
                .HasColumnType("decimal(18,2)"); // Specifikoni tipin dhe shkallën e kolonës për pronën 'CurrentAccountBalance'


            modelBuilder.Entity<Customer>()
                .Property(c => c.Balance)
                .HasColumnType("decimal(18,2)"); // Specifikoni tipin dhe shkallën e kolonës për pronën 'Balance'

            modelBuilder.Entity<Transaction>()
            .Property(t => t.TransactionAmount)
            .HasColumnType("decimal(18,2)"); // Specifikoni tipin dhe shkallën e kolonës për pronën 'TransactionAmount'
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
