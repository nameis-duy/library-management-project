using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookLendingDetailRepository : IBookLendingDetailRepository
    {
        public IEnumerable<BookLendingDetail> GetListDetails() => BookLendingDetailDAO.Instance.GetListBookLending();
        public void AddBookLendingDetail(BookLendingDetail bookLendingDetail) => BookLendingDetailDAO.Instance.AddLendingDetail(bookLendingDetail);
    }
}
