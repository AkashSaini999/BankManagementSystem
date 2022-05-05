using BankManagementSystem.Data;

namespace BankManagementSystem.Repository
{
    public interface ILoanRepository
    {
        Loan AddLoan(Loan loan);
    }
}
