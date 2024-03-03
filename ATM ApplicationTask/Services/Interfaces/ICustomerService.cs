using ATM_ApplicationTask.Models;
using System.Collections.Generic;

namespace ATM_ApplicationTask.Services.Interfaces
{
    public interface ICustomerService
    {
        // Kthen një listë të gjithë klientëve
        IEnumerable<Customer> GetAllCustomers();

        // Kthen një klient duke përdorur ID-në e klientit
        Customer GetCustomerById(int customerId);

        // Krijon një klient të ri
        void CreateCustomer(Customer customer);

        // Përditëson një klient ekzistues
        void UpdateCustomer(Customer customer);

        // Fshin një klient
        void DeleteCustomer(int customerId);
    }
}
