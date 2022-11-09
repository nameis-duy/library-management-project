using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ILibrarianRepository
    {
        Librarian? GetLibrarian(string username, string password);
        void UpdateInfo(Librarian librarian);
        Librarian? GetLibrarianName(int librarianID);
    }
}
