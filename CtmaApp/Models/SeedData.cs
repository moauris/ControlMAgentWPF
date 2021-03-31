using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CtmaApp.AppSecurityService;
using Microsoft.EntityFrameworkCore;

namespace CtmaApp.Models
{
    public static class SeedData
    {
        public static void PopulateData(DataContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
            if(!context.tbl_MachineInfo.Any() && !context.tbl_OSInfo.Any())
            {
                OSInfo rhel72bit64 = new OSInfo
                {
                    Platform = "Red Hat Enterprise Linux",
                    Version = "6",
                    Architecture = "64-bit"
                };
                context.tbl_OSInfo.AddRange(
                    new OSInfo 
                    { 
                        Platform = "Red Hat Enterprise Linux",
                        Version = "5.11",
                        Architecture = "32-bit"
                    },
                    new OSInfo
                    {
                        Platform = "Red Hat Enterprise Linux",
                        Version = "5.11",
                        Architecture = "64-bit"
                    },
                    new OSInfo
                    {
                        Platform = "Red Hat Enterprise Linux",
                        Version = "7.2",
                        Architecture = "64-bit"
                    },
                    new OSInfo
                    {
                        Platform = "Microsoft Windows",
                        Version = "10 Professional Edition",
                        Architecture = "64-bit"
                    },
                    new OSInfo
                    {
                        Platform = "Microsoft Windows",
                        Version = "10 Enterprise Edition",
                        Architecture = "64-bit"
                    },
                    rhel72bit64
                    );



                var m1 = new MachineInfo
                {
                    HostName = "TST00101",
                    Domain = "gdce.northwave.com.jp",
                    IPv4 = new IPAddress(new byte[] { 127, 188, 23, 10 }),
                    IPv6 = new IPAddress(new byte[]
                        {
                            237, 66, 73, 22,
                            0, 83, 54, 59,
                            0, 0, 77, 43,
                            127, 188, 23, 10
                        }),
                    OS = rhel72bit64
                };
                var m2 = new MachineInfo
                {
                    HostName = "TST00201",
                    Domain = "gdce.northwave.com.jp",
                    IPv4 = new IPAddress(new byte[] { 127, 188, 23, 11 }),
                    IPv6 = new IPAddress(new byte[]
                        {
                            237, 66, 73, 22,
                            0, 83, 54, 59,
                            0, 0, 77, 43,
                            127, 188, 23, 11
                        }),
                    OS = rhel72bit64
                };
                context.tbl_MachineInfo.AddRange(m1, m2);

                var s1 = new ServerInfo
                {
                    Host = m1,
                    Version = CtmVersion.v9018,
                    DefaultS2APort = 7005
                };
                var s2 = new ServerInfo
                {
                    Host = m2,
                    Version = CtmVersion.v9018,
                    DefaultS2APort = 7005
                };


                context.tbl_ServerInfo.AddRange(s1, s2);

                context.tbl_Users.AddRange(
                    CryptoServices.Register(
                        "ctmaAdmin",
                        "c7m@Adm1n".ToSecureSTR(),
                        new string[] {"admin", "power_user"}
                        ),
                    CryptoServices.Register(
                        "MomiCat",
                        "M0mic@t".ToSecureSTR(),
                        new string[] { "power_user" }
                        ),
                    CryptoServices.Register(
                        "ChenMo",
                        "Ch2nM0".ToSecureSTR(),
                        new string[] { "user" }
                        )
                    );

                context.SaveChanges();
            }
        }
    }
}
