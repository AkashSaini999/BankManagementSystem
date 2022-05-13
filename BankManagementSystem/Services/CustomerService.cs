using BankManagementSystem.Data;
using BankManagementSystem.Extensions;
using BankManagementSystem.Interface;
using BankManagementSystem.Repository;
using Microsoft.Extensions.Logging;
using System;

namespace BankManagementSystem.Services
{
    public class CustomerService:ICustomer
    {        
        public readonly ILogger _ilogger;
        public IcustomerRespository _customerRepositroy;
        public CustomerService(IcustomerRespository customerRepositroy, ILogger ilogger)
        {            
            _customerRepositroy = customerRepositroy;
            _ilogger = ilogger;
        }

        public Customer CreateNewCustomer(Customer customer)
        {
            try
            {
                _ilogger.LogInformation("Adding new customer");
                customer.CreatedDate = DateTime.UtcNow;
                var newCustomer = _customerRepositroy.AddCustomer(customer);
                _ilogger.LogInformation("Customer data saved to db succesfully");
                return newCustomer;
            }
            catch(Exception ex)
            {
                _ilogger.LogError(ex.Message);
                throw new BankManagemnetException(ex.Message);
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
                customer.Updateddate = DateTime.UtcNow;
                var newCustomer = _customerRepositroy.UpdateCustomer(customer);
                _ilogger.LogInformation("Customer data saved to db succesfully");
                return newCustomer;
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                throw new BankManagemnetException(ex.Message);
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
