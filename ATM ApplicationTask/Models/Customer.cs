using System.ComponentModel.DataAnnotations.Schema;

namespace ATM_ApplicationTask.Models
{
    [Table("Customer")]
    public class Customer
    {
        public int CustomerId { get; set; } //Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string PIN { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public List<Account> Accounts { get; set; } //Akaunt qe i perkasin klientit

        public Customer (int customerid, string firstname, string lastname, string cardNumber, string pin, decimal balance, string address, string email, string gender, string phoneNumber)
        {
            CustomerId = customerid;
            FirstName = firstname;
            LastName = lastname;
            CardNumber = cardNumber;
            PIN = pin;
            Balance = balance;
            Address = address;
            Email = email;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Accounts = new List<Account>();
        }
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }
}
