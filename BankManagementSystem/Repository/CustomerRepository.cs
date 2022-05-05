using BankManagementSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace BankManagementSystem.Repository
{
    public class CustomerRepository:IcustomerRespository
    {
        public readonly BankDbContext _bankDBContext;
        public IcustomerRespository _customerRepositroy;
        public CustomerRepository(BankDbContext bankDBContext, IcustomerRespository customerRepositroy)
        {
            _bankDBContext = bankDBContext;
            _customerRepositroy = customerRepositroy;
        }

        public Customer AddCustomer(Customer customer)
        {
            _bankDBContext.customers.Add(customer);
            _bankDBContext.SaveChanges();
            return customer;
        }

        public Customer GetCustomerById(int Id)
        {
            var customerDetails = _bankDBContext.customers.First(a => a.CustomerId == Id);
            return customerDetails;
        }

        public List<Customer> GetCustomerList()
        {
            var customerDetails = _bankDBContext.customers.ToList();
            return customerDetails;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var customerDetails=_bankDBContext.customers.First(a => a.CustomerId == customer.CustomerId);
            if(customerDetails!=null)
            {
                customerDetails = customer;
            }
            _bankDBContext.SaveChanges();
            return customer;
        }
    }
}
