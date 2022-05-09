using BankManagementSystem.Data;
using BankManagementSystem.Interface;
using BankManagementSystem.Repository;
using Microsoft.Extensions.Logging;
using System;

namespace BankManagementSystem.Services
{
    public class LoanService : ILoan
    {
        public readonly ILogger _ilogger;
        public ILoanRepository _loanRepository;
        public IcustomerRespository _customerRepositroy;
        public LoanService(ILoanRepository loanRepository, IcustomerRespository customerRepositroy, ILogger ilogger)
        {
            _customerRepositroy = customerRepositroy;
            _ilogger = ilogger;
            _loanRepository = loanRepository;

        }
        public Loan ApplyLoan(Loan loan)
        {
            try
            {
                var customer = _customerRepositroy.GetCustomerById(loan.CustomerId);
                if (customer == null)
                {
                    _ilogger.LogError("Customer Not Found Exception");
                    throw new Exception("Customer Not Found Exception");
                }
                var newLoan = _loanRepository.AddLoan(loan);
                return newLoan;
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
