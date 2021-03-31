using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.Models
{
    public class DataContext : DbContext
    {
        public DbSet<MachineInfo> tbl_MachineInfo { get; set; }
        public DbSet<OSInfo> tbl_OSInfo { get; set; }
        public DbSet<AgentInfo> tbl_AgentInfo { get; set; }
        public DbSet<ServerInfo> tbl_ServerInfo { get; set; }
        public DbSet<UserAccount> tbl_Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = 
                "Server=(localdb)\\MSSQLLocalDB;" + 
                "Database=CtmaAppDb;" +
                "MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //DONE: Find how to map model property Agent Version
            builder.Entity<AgentInfo>()
                .Property(p => p.Version)
                .HasConversion(
                ctmVer => ctmVer.version,
                ver => new CtmVersion(ver));
            builder.Entity<ServerInfo>()
                .Property(p => p.Version)
                .HasConversion(
                ctmVer => ctmVer.version,
                ver => new CtmVersion(ver));
            builder.Entity<UserAccount>()
                .Property(u => u.Roles)
                .HasConversion(
                strArr => ConvertFromStrArr(strArr),
                str => ConvertFromStr(str));
        }

        private string ConvertFromStrArr(string[] original)
            => string.Join(";", original);
        private string[] ConvertFromStr(string original)
            => original.Split(';');
    }
}
