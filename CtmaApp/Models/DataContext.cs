﻿using Microsoft.EntityFrameworkCore;
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
            //TODO: Find how to map model property Agent Version
        }
    }
}
