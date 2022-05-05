using BankManagementSystem.Data;

namespace BankManagementSystem.Interface
{
    public interface ILoan
    {
        Loan ApplyLoan(Loan loan);
    }
}
