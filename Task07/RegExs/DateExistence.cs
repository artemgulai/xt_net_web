using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    public class DateExistence
    {
        public static bool IfDateExists(string input)
        {
            Regex regex = new Regex(@"\b([0-2][0-9]|3[01])-(1[012]|0[1-9])-\d{4}\b");
            return regex.IsMatch(input);
        }
    }
}
