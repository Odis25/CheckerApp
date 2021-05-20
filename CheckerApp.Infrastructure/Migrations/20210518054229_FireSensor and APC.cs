using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class FireSensorandAPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.CreateTable(
                name: "APCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APCs_Hardwares_Id",
                        column: x => x.Id,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FireSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireSensors_Hardwares_Id",
                        column: x => x.Id,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APCs");

            migrationBuilder.DropTable(
                name: "FireSensors");          
        }
    }
}
