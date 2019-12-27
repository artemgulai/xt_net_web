using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    public class NumberValidator
    {
        // -?\d+(\.\d+)? -- usual notation
        // -?\d\.\d+[1-9]e-?[1-9](\d+)? -- scientific notation

        public static bool IsUsusalNotation(string input)
        {
            Regex regex = new Regex(@"^-?\d+(\.\d+)?$");
            return regex.IsMatch(input);
        }

        public static bool IsScientificNotation(string input)
        {
            Regex regex = new Regex(@"^-?\d\.\d+[1-9]e-?[1-9](\d+)?$");
            return regex.IsMatch(input);
        }
    }
}
