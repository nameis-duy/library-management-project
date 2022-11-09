using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookLending
    {
        public int LendingID { get; set; }
        public Student Student { get; set; }
        public Librarian Librarian { get; set; }
        public DateTime lendDate { get; set; }
        public DateTime? returnDate { get; set; }
        public DateTime deadline { get; set; }
    }
}
