using Microsoft.EntityFrameworkCore.Migrations;

namespace CtmaApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_OSInfo",
                columns: table => new
                {
                    OSInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Architecture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OSInfo", x => x.OSInfoID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MachineInfo",
                columns: table => new
                {
                    MachineInfoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPv4 = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    IPv6 = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    OSInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MachineInfo", x => x.MachineInfoID);
                    table.ForeignKey(
                        name: "FK_tbl_MachineInfo_tbl_OSInfo_OSInfoID",
                        column: x => x.OSInfoID,
                        principalTable: "tbl_OSInfo",
                        principalColumn: "OSInfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MachineInfo_OSInfoID",
                table: "tbl_MachineInfo",
                column: "OSInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_MachineInfo");

            migrationBuilder.DropTable(
                name: "tbl_OSInfo");
        }
    }
}
