using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public class MachineInfo
    {
        public long MachineInfoID { get; set; }
        public string HostName { get; set; }
        public string Domain { get; set; }
        //TODO: Need to limit ipv4/6 string input conversion
        public IPAddress IPv4 { get; set; }
        public IPAddress IPv6 { get; set; }
        public OSInfo OS { get; set; }

        public string GetFQDN() => $"{HostName}.{Domain}";

    }
}
