using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public class UserAccount
    {
        public long UserAccountID { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
        public string SaltedHash { get; set; }
    }
}
