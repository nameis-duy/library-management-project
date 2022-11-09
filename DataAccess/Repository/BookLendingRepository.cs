using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookLendingRepository : IBookLendingRepository
    {
        public IEnumerable<BookLending> GetListLending() => BookLendingDAO.Instance.GetListBookLending();
        public int GetNextSeed() => BookLendingDAO.Instance.GetNextSeed();
        public void AddLending(BookLending book) => BookLendingDAO.Instance.AddBookLending(book);
        public void UpdateLending(BookLending book) => BookLendingDAO.Instance.UpdateBookLending(book);
    }
}
