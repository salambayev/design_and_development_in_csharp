using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Design_and_Development_in_Csharp
{
    class Program
    {
        public static bool IsPhone(string s)
        {
            return Regex.IsMatch(s, @"^\(?\d{3}\)?[\s\-]?\d{3}\-?\d{4}$");
        }

        public static bool IsZip(string s)
        {
            return Regex.IsMatch(s, @"^\d{5}(\-\d{4})?$");
        }

        public static bool IsEmail(string s)
        {
            return Regex.IsMatch(s, @"^([\w\.\-]+)@([\w\-]+)((\.\w{2,3})+)$");
        }

        public static string ReforMat (string s)
        {
            Match reg = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
            return String.Format("({0}) {1} - {2}", reg.Groups[1], reg.Groups[2], reg.Groups[3]);
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(IsEmail(s));
            string phone = Console.ReadLine();
            Console.WriteLine(ReforMat(phone));
        }
    }
}
