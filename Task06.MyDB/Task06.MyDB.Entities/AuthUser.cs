using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.MyDB.Entities
{
    public class AuthUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public HashSet<string> Roles { get; set; }
    }
}
