using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataModel.Business;

namespace Library.Database.Managers
{
    public interface IBookManager: IDisposable
    {
        Book GetBook(int bookCode);
        IEnumerable<Book> GetBooks();
        Book SetBook(Book book);
        void DeleteBook(int bookCode);
    }
}
