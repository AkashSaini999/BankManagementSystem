using BankManagementSystem.Data;
using BankManagementSystem.Helpers;
using BankManagementSystem.Interface;
using BankManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class AuthenticationService: IAuthentication
    {
        private readonly JwtSettings _jwtSettings;
        public readonly BankDbContext _bankDBContext;
        public AuthenticationService(JwtSettings jwtSettings, BankDbContext bankDBContext)
        {
            this._jwtSettings = jwtSettings;
            _bankDBContext = bankDBContext;
        }
        public UserTokens Authenticate(Users user)
        {
            var Token = new UserTokens();
            Token = JwtHelpers.GenTokenkey(new UserTokens()
            {
                EmailId = user.EmailId,
                GuidId = Guid.NewGuid(),
                UserName = user.UserName,
                Id = user.Id,
            }, _jwtSettings);

            return Token;
        }

        public Users IsValidCustomer(UserLogins userLogins)
        {
            try
            {
                var customer = _bankDBContext.customers.Where(x => x.Username == userLogins.UserName && x.Password == userLogins.Password).FirstOrDefault();
                var users = new Users() { EmailId = customer.EmailId, Id = customer.CustomerId, Password = customer.Password, UserName = customer.Username };
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_bankDBContext != null)
                    _bankDBContext.Dispose();
            }
        }
    }
}
