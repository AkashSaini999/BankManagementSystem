using BankManagementSystem.Data;
using System.Collections.Generic;

namespace BankManagementSystem.Repository
{
    public interface IcustomerRespository
    {
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);

        List<Customer> GetCustomerList();
        Customer GetCustomerById(int Id);
    }
}
