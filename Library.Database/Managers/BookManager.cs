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
    public class BookManager: BaseManager, IBookManager
    {
        protected BookRepository Books;
        public BookManager(DataModelContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext), "The data container cannot be undefined");
            }

            DbContext = dbContext;
            ContextAdapter = new DbContextAdapter(dbContext);
            Books = new BookRepository(ContextAdapter);
        }
        public void Dispose()
        {
            if (ContextAdapter != null)
            {
                ContextAdapter.Dispose();
                ContextAdapter = null;
            }

            DbContext = null;
            Books = null;
        }

        public Book GetBook(int bookCode)
        {
            var book = Books.FirstOrDefault(be => be.Code.Equals(bookCode));
            return book?.Map<BookEntity, Book>();
        }

        public IEnumerable<Book> GetBooks()
        {
            return Books.GetAll().Map<BookEntity, Book>();
        }

        public Book SetBook(Book book)
        {
            try
            {
                // Validate parameters.
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Cannot set an undefined book");
                }

                var bookEntity = Books.FirstOrDefault(ue => ue.Code.Equals(book.Code));
                if (bookEntity == null)
                {
                    // Insert a new entity.

                    bookEntity = book.Map<Book, BookEntity>();

                    Books.Insert(bookEntity);
                    ContextAdapter.SaveChanges();

                }
                else
                {
                    // Update an existing entity.
                    Mappings.Map(book, bookEntity);
                    Books.Update(bookEntity);
                    ContextAdapter.SaveChanges();

                }

                return bookEntity.Map<BookEntity, Book>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteBook(int bookCode)
        {
            // Find the book.
            var book = Books.FirstOrDefault(be => be.Code.Equals(bookCode));
            if (book == null)
            {
                throw new ArgumentException($"Could not find any Book with the Code '{bookCode}' to delete.");
            }

            // Delete the book.
            Books.Delete(book);
            ContextAdapter.SaveChanges();
        }
    }
}
