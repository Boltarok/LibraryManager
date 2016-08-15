using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataModel.Business;

namespace Library.Database.Managers
{
    public class LoanManager: ILoanManager
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Loan GetLoan(int loanNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> GetLoans()
        {
            throw new NotImplementedException();
        }

        public Book SetLoan(Loan loan)
        {
            throw new NotImplementedException();
        }

        public void DeleteLoan(int loanNumber)
        {
            throw new NotImplementedException();
        }
    }
}
