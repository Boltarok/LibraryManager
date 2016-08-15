using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel.Business
{
    public class Loan
    {
        public int Number { get; set; }
        public DateTime LoanDate { get; set; }
        public int MemberNumber { get; set; }
        public int BookCode { get; set; }
    }
}
