using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ATM_ApplicationTask.Models
{
    [Table("Account")]
    public class Account
    {
        public int AccountId { get; set; } // Primary Key
        public int CustomerId { get; set; } // Foreign Key
        public string AccountName { get; set; }
        public string CardNumber { get; set; }
        public string PIN { get; set; }
        public decimal CurrentAccountBalance { get; set; }
        public string Email { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdate { get; set; }
        public List<Transaction> Transactions { get; set; } //Transaksionet qe jane kryer ne akaunt

    }
}

public enum AccountType
{
    Savings,
    Current,
    Corporate,
    Governent
}
