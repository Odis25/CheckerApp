using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class FireSensorandAPCnewfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<string>(
                name: "DeviceModel",
                table: "FireSensors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "FireSensors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceModel",
                table: "APCs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "APCs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "DeviceModel",
                table: "FireSensors");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "FireSensors");

            migrationBuilder.DropColumn(
                name: "DeviceModel",
                table: "APCs");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "APCs");

        }
    }
}
