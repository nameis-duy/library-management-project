using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookLendingDetail
    {
        public int LendID { get; set; }
        public int bookID { get; set; }
        public string bookTitle { get; set; }
        public int quantity { get; set; }
    }
}
