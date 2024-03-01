using Microsoft.EntityFrameworkCore;
using ATM_ApplicationTask.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace ATM_AplicationTask.Data
{ 
    public class ATMDbContext : DbContext
    {
               
        public ATMDbContext(DbContextOptions<ATMDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
