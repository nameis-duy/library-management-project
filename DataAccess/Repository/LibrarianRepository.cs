using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class LibrarianRepository : ILibrarianRepository
    {
        public Librarian? GetLibrarian(string username, string password) => LibrarianDAO.Instance.CheckLogin(username, password);
        public void UpdateInfo(Librarian librarian) => LibrarianDAO.Instance.UpdateInfo(librarian);
        public Librarian? GetLibrarianName(int librarianID) => LibrarianDAO.Instance.GetInfo(librarianID);
    }
}
