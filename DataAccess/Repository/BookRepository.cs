using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAllBooks() => BookDAO.Instance.GetBookList();
        public int GetNewProperBookID() => BookDAO.Instance.GetNextSeed();
        public void AddBook(Book book) => BookDAO.Instance.AddBook(book);
        public void UpdateBook(Book book) => BookDAO.Instance.UpdateBook(book);
    }
}
