using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public class AgentInfo
    {
        public long AgentInfoID { get; set; }
        public MachineInfo Host { get; set; }
        public int PortA2S { get; set; }
        public int PortS2A { get; set; }
        public CtmVersion Version { get; set; }
    }


}
