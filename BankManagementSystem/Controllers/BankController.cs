using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using BankManagementSystem.Helpers;
using BankManagementSystem.Interface;
using BankManagementSystem.Data;
using BankManagementSystem.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly ICustomer _customerService;
        private readonly ILoan _loanService;
        public BankController(ICustomer customer, ILoan loan)
        {
            _customerService = customer;
            _loanService = loan;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("addcustomer")]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            try
            {
                var IsvalidEmailId=ArgumentValidation.ValidateEmail(customer.EmailId);
                var isValidphone = ArgumentValidation.IsPhoneNbr(customer.ContactNo);
                if (!IsvalidEmailId||!isValidphone)
                return BadRequest("Please enter valid phoen number or emailid");

                var result = _customerService.CreateNewCustomer(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new BankManagemnetException(ex.Message);
            }
        }

        [HttpPut]
        [Route("updatecustomer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                var result = _customerService.UpdateCustomerInfo(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new BankManagemnetException(ex.Message);
            }
        }
        [HttpPost]
        [Route("applyloan")]
        public IActionResult ApplyLoan([FromBody] Loan loan)
        {
            try
            {
                var result = _loanService.ApplyLoan(loan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new BankManagemnetException(ex.Message);
            }
        }

        
    }
}
