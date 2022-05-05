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
    public class LoanService:ILoan
    {
        public readonly ILogger _ilogger;
        public ILoanRepository _loanRepository;
        public IcustomerRespository _customerRepositroy;
        public LoanService(ILoanRepository loanRepository, IcustomerRespository customerRepositroy)
        {
            _customerRepositroy = customerRepositroy;
        }
       public  Loan ApplyLoan(Loan loan)
        {
            var customer = _customerRepositroy.GetCustomerById(loan.CustomerId);
            if(customer==null)
            {
                _ilogger.LogError("Customer Not Found Exception");
                throw new Exception("Customer Not Found Exception");

            }
            var newLoan = _loanRepository.AddLoan(loan);
            return newLoan;
        }
    }
}
