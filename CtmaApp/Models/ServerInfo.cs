using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public class ServerInfo
    {
        public long ServerInfoID { get; set; }
        public MachineInfo Host { get; set; }
        public int DefaultS2APort { get; set; }
        public CtmVersion Version { get; set; }
    }
}
