﻿// <auto-generated />
using System;
using CtmaApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CtmaApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CtmaApp.Models.AgentInfo", b =>
                {
                    b.Property<long>("AgentInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("HostMachineInfoID")
                        .HasColumnType("bigint");

                    b.Property<int>("PortA2S")
                        .HasColumnType("int");

                    b.Property<int>("PortS2A")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentInfoID");

                    b.HasIndex("HostMachineInfoID");

                    b.ToTable("tbl_AgentInfo");
                });

            modelBuilder.Entity("CtmaApp.Models.MachineInfo", b =>
                {
                    b.Property<long>("MachineInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPv4")
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("IPv6")
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("OSInfoID")
                        .HasColumnType("int");

                    b.HasKey("MachineInfoID");

                    b.HasIndex("OSInfoID");

                    b.ToTable("tbl_MachineInfo");
                });

            modelBuilder.Entity("CtmaApp.Models.OSInfo", b =>
                {
                    b.Property<int>("OSInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Architecture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OSInfoID");

                    b.ToTable("tbl_OSInfo");
                });

            modelBuilder.Entity("CtmaApp.Models.ServerInfo", b =>
                {
                    b.Property<long>("ServerInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DefaultS2APort")
                        .HasColumnType("int");

                    b.Property<long?>("HostMachineInfoID")
                        .HasColumnType("bigint");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServerInfoID");

                    b.HasIndex("HostMachineInfoID");

                    b.ToTable("tbl_ServerInfo");
                });

            modelBuilder.Entity("CtmaApp.Models.UserAccount", b =>
                {
                    b.Property<long>("UserAccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaltedHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserAccountID");

                    b.ToTable("tbl_Users");
                });

            modelBuilder.Entity("CtmaApp.Models.AgentInfo", b =>
                {
                    b.HasOne("CtmaApp.Models.MachineInfo", "Host")
                        .WithMany()
                        .HasForeignKey("HostMachineInfoID");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("CtmaApp.Models.MachineInfo", b =>
                {
                    b.HasOne("CtmaApp.Models.OSInfo", "OS")
                        .WithMany()
                        .HasForeignKey("OSInfoID");

                    b.Navigation("OS");
                });

            modelBuilder.Entity("CtmaApp.Models.ServerInfo", b =>
                {
                    b.HasOne("CtmaApp.Models.MachineInfo", "Host")
                        .WithMany()
                        .HasForeignKey("HostMachineInfoID");

                    b.Navigation("Host");
                });
#pragma warning restore 612, 618
        }
    }
}
