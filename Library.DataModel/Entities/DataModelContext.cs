using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel.Entities
{
    public class DataModelContext:DbContext
    {
        public DataModelContext()
            : base("name=LibraryConnectionString")
        {
            
        }

        public DbSet <LoanEntity> Loans { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
    }
}
