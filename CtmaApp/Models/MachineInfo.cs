using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public class MachineInfo
    {
        [Key]
        public long MachineInfoID { get; set; }
        public string HostName { get; set; }
        public string Domain { get; set; }
        //TODO: Need to limit ipv4/6 string input conversion
        public IPAddress IPv4 { get; set; }
        public IPAddress IPv6 { get; set; }
        public OSInfo OS { get; set; }

        public string GetFQDN() => $"{HostName}.{Domain}";

        internal string ToSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("FQDN:");
            sb.AppendLine(GetFQDN());
            //TODO: Need Value Converter to convert IP Address from string and back
            sb.Append("IPv4:");
            sb.AppendLine(IPv4?.ToString()); 
            sb.Append("IPv6:");
            sb.AppendLine(IPv6?.ToString());
            sb.Append("OSInfo:");
            sb.AppendLine(OS?.ToString());

            return sb.ToString();

        }
    }
}
