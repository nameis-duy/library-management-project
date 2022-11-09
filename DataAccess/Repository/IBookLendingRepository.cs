using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookLendingRepository
    {
        IEnumerable<BookLending> GetListLending();
        int GetNextSeed();
        void AddLending(BookLending book);
        void UpdateLending(BookLending book);
    }
}
