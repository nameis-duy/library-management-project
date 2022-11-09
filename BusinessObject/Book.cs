using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Book
    {
        public Book()
        {
        }

        public int BookID { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Printer { get; set; }
        public string Author { get; set; }
        public string PublishYear { get; set; }
        public int Quantity { get; set; }
        public Double Price { get; set; }

        public override string? ToString()
        {
            return "[#" + BookID.ToString() + "]" + "   " + Title;
        }
    }
}
