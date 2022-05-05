using BankManagementSystem.Interface;
using BankManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication authentication;
        public AuthenticationController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }
       
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserLogins userLogins)
        {
            try
            {
                var user = authentication.IsValidCustomer(userLogins);
                if (user!=null)
                {                   
                    var Token = authentication.Authenticate(user);
                    return Ok(Token);
                }
                else
                {
                    return Unauthorized();
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
