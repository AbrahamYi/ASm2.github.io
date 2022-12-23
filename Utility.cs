using Asm2._2_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading.Tasks;
namespace Asm2._2_Hotel.Utils
{
    public class Utility
    {
        public static DateTime ConvertStringToDateTime(string str)
        {
            //format: YYYY-MM-dd HH:mm:ss
            DateTime outputDateTimeValue;
            if (DateTime.TryParseExact(str, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out outputDateTimeValue))
            {
                return outputDateTimeValue;
            }
            return new DateTime();
        }

        //Format: yyyy-MM-dd HH:mm:ss
        public static string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}