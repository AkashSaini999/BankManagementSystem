using BankManagementSystem.Controllers;
using BankManagementSystem.Data;
using BankManagementSystem.Helpers;
using BankManagementSystem.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

namespace BankManagementsystem.Test
{
    public class BankTest
    {        
        private Mock<ICustomer> _customerService;
        private Mock<ILoan> _loanService;
        public Customer _customer;
        public Loan _loan;
        [SetUp]
        public void Setup()
        {
            _customerService = new Mock<ICustomer>();
            _loanService = new Mock<ILoan>();
            _customer = new Customer() { Name = "anna", Username = "anna", Password = "password1", ContactNo = "9600209432", EmailId = "anna@anna.com", Address = "Changanassery", Country = "India", State = "Kerala", AccountType = "Savings", DOB = Convert.ToDateTime("13-07-1994"), CreatedDate = DateTime.UtcNow, Pan = "BPFPN9256N" };
            _loan = new Loan() { CustomerId = 1, LoanType = "Personal", LoanAmount = 200000, LoanDate = DateTime.UtcNow, LoanDuration = 24, ROI = 7 };
        }
        #region Validations
        
        [TestCase("anna#gmail.com")]
        [TestCase("anna@gmail")]
        [TestCase("anna@gmailcom")]
        public void IsNotValidEmail(string value)
        {
            bool isValid = ArgumentValidation.ValidateEmail(value);
            Assert.IsFalse(isValid);
        }

        [TestCase("anna@gmail.com")]
        public void IsValidEmail(string value)
        {
            bool isValid = ArgumentValidation.ValidateEmail(value);
            Assert.IsTrue(isValid);
        }

        [TestCase("sdgjadjhasdmkjd")]
        [TestCase("564738921")]
        public void IsNotValidPhoneNumber(string value)
        {
            bool isValid = ArgumentValidation.IsPhoneNbr(value);
            Assert.IsFalse(isValid);
        }

        [TestCase("8086309013")]
        [TestCase("9645522343")]
        public void IsValidPhoneNumber(string value)
        {
            bool isValid = ArgumentValidation.IsPhoneNbr(value);
            Assert.IsTrue(isValid);
        }
        #endregion

        #region ControllerValidation
       
        [Test]
        public void AddCustomer_OkResult()
        {
            // Arrange
            _customerService.Setup(x => x.CreateNewCustomer(_customer));
           
            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Act
            var actionResult = controller.AddCustomer(_customer);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void AddCustomer_ThrowsException()
        {
            // Arrange
            _customerService.Setup(x => x.CreateNewCustomer(_customer)).Throws(new Exception());
            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.AddCustomer(_customer));
        }

        [Test]
        public void UpdateCustomer_OkResult()
        {
            // Arrange
            _customerService.Setup(x => x.UpdateCustomerInfo(_customer));

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Act
            var actionResult = controller.UpdateCustomer(_customer);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void Updatecustomer_ThorowsException()
        {
            // Arrange
            _customerService.Setup(x => x.UpdateCustomerInfo(_customer)).Throws(new Exception());

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.UpdateCustomer(_customer));
        }

        [Test]
        public void ApplyLoan_OkResult()
        {
            // Arrange
            _loanService.Setup(x => x.ApplyLoan(_loan));

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Act
            var actionResult = controller.ApplyLoan(_loan);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public void Updatecustomer_ThrowsException()
        {
            // Arrange
            _loanService.Setup(x => x.ApplyLoan(_loan)).Throws(new Exception());

            var controller = new BankController(_customerService.Object, _loanService.Object);

            // Assert
            Assert.Throws<Exception>(() => controller.ApplyLoan(_loan));
        }
        #endregion
    }
}