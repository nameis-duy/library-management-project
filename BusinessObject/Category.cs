using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public override string ToString()
        {
            return CategoryTitle;
        }
    }
}
