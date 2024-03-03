using ATM_AplicationTask.Data;
using ATM_ApplicationTask.Models;
using ATM_ApplicationTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net.NetworkInformation;

namespace ATM_ApplicationTask.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private ATMDbContext _dbContext;
        public AccountService(ATMDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AccountType Authenticate(string AccountNumber, string Pin)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.CardNumber == AccountNumber && a.PIN == Pin);
            return account != null ? account.AccountType : AccountType.Savings;
        }

        public Account Create(Account account, string Pin, string ConfirmPin)
        {
            if (Pin != ConfirmPin)
            {
                throw new Exception("PIN-i i konfirmimit nuk perputhet.");
            }

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return account;
        }

        public void Delete(int AccountId)
        {
            var account = _dbContext.Accounts.Find(AccountId);
            if (account == null)
            {
                throw new Exception("Llogaria nuk u gjet.");
            }

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetByAccountId(int AccountId)
        {
            return _dbContext.Accounts.Find(AccountId);
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            return _dbContext.Accounts.FirstOrDefault(a => a.CardNumber == AccountNumber);
        }

        public void Update(Account account, string Pin = null)
        {
            var existingAccount = _dbContext.Accounts.Find(account.AccountId);
            if (existingAccount == null)
            {
                throw new Exception("Llogaria nuk u gjet.");
            }

            existingAccount.AccountName = account.AccountName;
            existingAccount.CurrentAccountBalance = account.CurrentAccountBalance;
            existingAccount.Email = account.Email;
            existingAccount.DateLastUpdate = DateTime.Now;

            if (!string.IsNullOrEmpty(Pin))
            {
                existingAccount.PIN = Pin;
            }

            _dbContext.SaveChanges();
        }
    }
    }

