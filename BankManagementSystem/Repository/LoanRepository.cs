using BankManagementSystem.Data;

namespace BankManagementSystem.Repository
{
    public class LoanRepository:ILoanRepository
    {
        public readonly BankDbContext _bankDBContext;
        public LoanRepository( BankDbContext bankDBContext)
        {            
            _bankDBContext = bankDBContext;
        }

        public Loan AddLoan(Loan loan)
        {
            _bankDBContext.Loans.Add(loan);
            _bankDBContext.SaveChanges();
            return loan;
        }
    }
}
