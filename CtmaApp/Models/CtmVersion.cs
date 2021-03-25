using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public struct CtmVersion
    {
        public CtmVersion(string ver)
        {
            version = ver;
        }
        public string version { get; private set; }
        public static CtmVersion v9018 => new CtmVersion("9.0.18");
        public static CtmVersion v7000fp5 => new CtmVersion("7.0.00 Fix Pack 5");
        public override string ToString() => version;
    }
}
