using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Librarian
    {
        public int LibrarianID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string? ToString()
        {
            return "[" + LibrarianID.ToString() + "]" + "   " + Name;
        }
    }
}
