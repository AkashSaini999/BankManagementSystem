using BankManagementSystem.Data;
using BankManagementSystem.Interface;
using BankManagementSystem.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class CustomerService:ICustomer
    {        
        public readonly ILogger _ilogger;
        public IcustomerRespository _customerRepositroy;
        public CustomerService(IcustomerRespository customerRepositroy)
        {            
            _customerRepositroy = customerRepositroy;
        }

        public Customer CreateNewCustomer(Customer customer)
        {
            try
            {
                _ilogger.LogInformation("Adding new customer");
                var newCustomer = _customerRepositroy.AddCustomer(customer);
                _ilogger.LogInformation("Customer data saved to db succesfully");
                return newCustomer;
            }
            catch(Exception ex)
            {
                _ilogger.LogError(ex.Message);
                throw ex;
            }
            
        }

        public Customer UpdateCustomerInfo(Customer customer)
        {
            try
            {

                var isExist = IscustomerExist(customer.CustomerId);
                if (!isExist)
                {
                    _ilogger.LogError("Customer Not Found Exception");
                    throw new Exception("Customer Not Found Exception");
                }
                _ilogger.LogInformation("Updating existing customer");
                var newCustomer = _customerRepositroy.AddCustomer(customer);
                _ilogger.LogInformation("Customer data saved to db succesfully");
                return newCustomer;
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                throw ex;
            }
        }

        public bool IscustomerExist(int id)
        {
            var customerInfo = _customerRepositroy.GetCustomerById(id);
            if (customerInfo != null)
                return true;
            else
                return false;
        }
    }
}
