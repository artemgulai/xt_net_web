using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    public class HtmlReplacer
    {
        public static string ReplaceTags(string input)
        {
            Regex regex = new Regex("<.+?>");
            return regex.Replace(input,"_");
        }
    }
}
