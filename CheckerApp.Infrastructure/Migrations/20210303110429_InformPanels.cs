using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class InformPanels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformPanels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanelType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformPanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformPanels_Hardwares_Id",
                        column: x => x.Id,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformPanels");
        }
    }
}
