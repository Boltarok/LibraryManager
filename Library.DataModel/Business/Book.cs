using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel.Business
{
    public class Book
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public int AmmountAvailable { get; set; }
        public string Status { get; set; }
    }
}
