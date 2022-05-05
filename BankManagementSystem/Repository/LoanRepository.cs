using BankManagementSystem.Data;

namespace BankManagementSystem.Repository
{
    public class LoanRepository:ILoanRepository
    {
        public readonly BankDbContext _bankDBContext;
        public ILoanRepository _loanRepository;
        public LoanRepository( BankDbContext bankDBContext, ILoanRepository loanRepository)
        {            
            _bankDBContext = bankDBContext;
            _loanRepository = loanRepository;
        }

        public Loan AddLoan(Loan loan)
        {
            _bankDBContext.Loans.Add(loan);
            _bankDBContext.SaveChanges();
            return loan;
        }
    }
}
