using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataModel.Business;

namespace Library.Database.Managers
{
    public interface ILoanManager: IDisposable
    {
        Loan GetLoan(int loanNumber);
        IEnumerable<Loan> GetLoans();
        Loan SetLoan(Loan loan);
        void DeleteLoan(int loanNumber);
    }
}
