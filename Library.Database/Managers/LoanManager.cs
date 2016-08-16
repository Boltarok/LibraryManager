using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Patterns;
using Library.Database.Repostories;
using Library.DataModel.Business;
using Library.DataModel.Entities;
using Library.DataModel.Mappings;

namespace Library.Database.Managers
{
    public class LoanManager: BaseManager, ILoanManager
    {
        protected LoanRepository Loans;
        public LoanManager(DataModelContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext), "The data container cannot be undefined");
            }

            DbContext = dbContext;
            ContextAdapter = new DbContextAdapter(dbContext);
            Loans = new LoanRepository(ContextAdapter);
        }
        public void Dispose()
        {
            if (ContextAdapter != null)
            {
                ContextAdapter.Dispose();
                ContextAdapter = null;
            }

            DbContext = null;
            Loans = null;
        }

        public Loan GetLoan(int loanNumber)
        {
            var book = Loans.FirstOrDefault(be => be.Number.Equals(loanNumber));
            return book?.Map<LoanEntity, Loan>();
        }

        public IEnumerable<Loan> GetLoans()
        {
            return Loans.GetAll().Map<LoanEntity, Loan>();
        }

        public Loan SetLoan(Loan loan)
        {
            try
            {
                // Validate parameters.
                if (loan == null)
                {
                    throw new ArgumentNullException(nameof(loan), "Cannot set an undefined loan");
                }

                var loanEntity = Loans.FirstOrDefault(le => le.Number.Equals(loan.Number));
                if (loanEntity == null)
                {
                    // Insert a new entity.

                    loanEntity = loan.Map<Loan, LoanEntity>();

                    Loans.Insert(loanEntity);
                    ContextAdapter.SaveChanges();

                }
                else
                {
                    // Update an existing entity.
                    Mappings.Map(loan, loanEntity);
                    Loans.Update(loanEntity);
                    ContextAdapter.SaveChanges();

                }

                return loanEntity.Map<LoanEntity, Loan>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLoan(int loanNumber)
        {
            // Find the loan.
            var loan = Loans.FirstOrDefault(le => le.Number.Equals(loanNumber));
            if (loan == null)
            {
                throw new ArgumentException($"Could not find any Loan with the Number '{loanNumber}' to delete.");
            }

            // Delete the loan.
            Loans.Delete(loan);
            ContextAdapter.SaveChanges();
        }
    }
}
