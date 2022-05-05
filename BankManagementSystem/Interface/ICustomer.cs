using BankManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Interface
{
    public interface ICustomer
    {
        Customer CreateNewCustomer(Customer customer);
        Customer UpdateCustomerInfo(Customer customer);
    }
}
