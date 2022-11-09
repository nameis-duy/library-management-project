using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Utils
{
    public static class StringFormat
    {
        public static String ConvertToVNDString(Double money)
        {
            CultureInfo VNstyle = new CultureInfo("vi-VN");
            VNstyle.NumberFormat.CurrencyGroupSeparator = " ";
            return string.Format(VNstyle, "{0:c}", money);
        }
        public static Double ConvertToVND(String VNDmoney)
        {
            if (VNDmoney == "") return 0;
            return Double.Parse(VNDmoney.Replace(" ", "").Replace("₫", "").Trim());
        }
    }
}
