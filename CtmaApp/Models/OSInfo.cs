using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public class OSInfo
    {
        public int OSInfoID { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
        public string Architecture { get; set; }
        public override string ToString()
        {
            return $"{Platform} {Version} {Architecture}";
        }
    }
}
