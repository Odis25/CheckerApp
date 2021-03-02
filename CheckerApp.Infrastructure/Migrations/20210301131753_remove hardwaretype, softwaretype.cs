using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class removehardwaretypesoftwaretype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "311f9ba2-4ca7-4d7f-8320-f0c98747d43f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "774d676f-d715-45fb-afa5-c0fa50f98b77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaab9e32-ad42-4a95-b9e4-650c2c7764ed");

            migrationBuilder.DropColumn(
                name: "SoftwareType",
                table: "Softwares");

            migrationBuilder.DropColumn(
                name: "HardwareType",
                table: "Hardwares");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64df788e-a8a8-4fda-9fc5-c5c1103186ef", "e91fd175-b17f-4375-a85d-c36c8098edcb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f78ef613-6166-4332-aaf6-d61568bb544b", "dec8d2c1-b960-495b-aa64-f11c1abed776", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da3a40cf-2654-46e7-9e1d-e52603514c10", "b6d2ba11-fb13-4d8d-b27b-5678acfad4b9", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64df788e-a8a8-4fda-9fc5-c5c1103186ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da3a40cf-2654-46e7-9e1d-e52603514c10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f78ef613-6166-4332-aaf6-d61568bb544b");

            migrationBuilder.AddColumn<int>(
                name: "SoftwareType",
                table: "Softwares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HardwareType",
                table: "Hardwares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eaab9e32-ad42-4a95-b9e4-650c2c7764ed", "7defd08b-f812-471f-9d5a-ce639d2e0abf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "774d676f-d715-45fb-afa5-c0fa50f98b77", "2da49433-bbd0-486b-a764-a8da0bf752f8", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "311f9ba2-4ca7-4d7f-8320-f0c98747d43f", "d7b11504-0341-41d9-b0b6-5886524b413d", "User", "USER" });
        }
    }
}
