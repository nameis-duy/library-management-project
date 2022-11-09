using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Generation { get; set; }
        public bool Gender { get; set; }
        public DateTime DOB { get; set; }
        public Double Debt { get; set; }

        public override string? ToString()
        {
            return "[" + StudentID.ToString() + "]" + "   " + Name; ;
        }
    }
}
