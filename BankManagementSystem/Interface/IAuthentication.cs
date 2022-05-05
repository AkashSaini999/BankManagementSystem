using BankManagementSystem.Model;

namespace BankManagementSystem.Interface
{
    public interface IAuthentication
    {
        UserTokens Authenticate(Users users);
        Users IsValidCustomer(UserLogins userLogins);
    }
}
