using BankManagementSystem.Data;
using Moq;
using NUnit.Framework;
using System;
using BankManagementSystem.Repository;
using BankManagementSystem.Services;
using Microsoft.Extensions.Logging;

namespace BankManagementsystem.Test
{
    public class ServiceTest
    {
        private Mock<IcustomerRespository> _customerService;
        private Mock<ILoanRepository> _loanService;
        private Mock<ILogger> _ilogger;
        public Customer _customer;
        public Loan _loan;

        [SetUp]
        public void Setup()
        {
            _customerService = new Mock<IcustomerRespository>();
            _ilogger = new Mock<ILogger>();
            _loanService = new Mock<ILoanRepository>();
            _customer = new Customer() { Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailId = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedDate = DateTime.UtcNow, Pan = "BPFPN9256N" };
            _loan = new Loan() { CustomerId = 1, LoanType = "Personal", LoanAmount = 200000, LoanDate = DateTime.UtcNow, LoanDuration = 24, ROI = 7 };
        }


        [Test]
        public void AddCustomer_OkResult()
        {
            // Arrange
            _customerService.Setup(x => x.AddCustomer(_customer)).Returns(_customer);

            var service = new CustomerService(_customerService.Object, _ilogger.Object);

            // Act
            var actionResult = service.CreateNewCustomer(_customer);

            // Assert           
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void ApplyLoan_OkResult()
        {
            // Arrange
            _loanService.Setup(x => x.AddLoan(_loan)).Returns(_loan);
            _customerService.Setup(x => x.GetCustomerById(_loan.CustomerId)).Returns(_customer);
            var service = new LoanService(_loanService.Object, _customerService.Object, _ilogger.Object);

            // Act
            var actionResult = service.ApplyLoan(_loan);

            // Assert           
            Assert.IsNotNull(actionResult);
        }
        [Test]
        public void AddCustomer_ThrowsException()
        {
            // Arrange
            _customerService.Setup(x => x.AddCustomer(_customer)).Throws(new Exception());
            var service = new CustomerService(_customerService.Object, _ilogger.Object);

            // Assert
            Assert.Throws<Exception>(() => service.CreateNewCustomer(_customer));
        }

        [Test]
        public void UpdateCustomer_OkResult()
        {
            // Arrange
            _customerService.Setup(x => x.UpdateCustomer(_customer)).Returns(_customer);
            _customerService.Setup(x => x.GetCustomerById(_customer.CustomerId)).Returns(_customer);

            var service = new CustomerService(_customerService.Object, _ilogger.Object);

            // Act
            var actionResult = service.UpdateCustomerInfo(_customer);

            // Assert           
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void UpdateCustomer_ThrowsException()
        {
            // Arrange
            _customerService.Setup(x => x.UpdateCustomer(_customer)).Throws(new Exception());
            var service = new CustomerService(_customerService.Object, _ilogger.Object);

            // Assert
            Assert.Throws<Exception>(() => service.UpdateCustomerInfo(_customer));
        }

        

        [Test]
        public void ApplyLoan_ThrowsException()
        {
            // Arrange
            _loanService.Setup(x => x.AddLoan(_loan)).Throws(new Exception());

            var service = new LoanService(_loanService.Object, _customerService.Object, _ilogger.Object);

            // Assert
            Assert.Throws<Exception>(() => service.ApplyLoan(_loan));
        }
    }
    
}
