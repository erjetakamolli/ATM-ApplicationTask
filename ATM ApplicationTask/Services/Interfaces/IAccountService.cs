using ATM_ApplicationTask.Models;

namespace ATM_ApplicationTask.Services.Interfaces
{

    public interface IAccountService
    {
        AccountType Authenticate(string AccountNumber, string Pin);
        IEnumerable<Account> GetAllAccounts();
        Account Create(Account account, string Pin, string ConfirmPin);
        void Update(Account account, string Pin = null);
        void Delete(int AccountId);
        Account GetByAccountId(int AccountId);
        Account GetByAccountNumber(string AccountNumber);
    }

}
