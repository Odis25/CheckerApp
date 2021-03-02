using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class addsoftwaretype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "64df788e-a8a8-4fda-9fc5-c5c1103186ef");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "da3a40cf-2654-46e7-9e1d-e52603514c10");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "f78ef613-6166-4332-aaf6-d61568bb544b");

            migrationBuilder.AddColumn<int>(
                name: "SoftwareType",
                table: "Softwares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "2f46c1a7-698e-4f51-821f-28308d751c5c", "872b7a12-3a82-4fb4-a4d4-328cd25e9882", "Admin", "ADMIN" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "dcc7d3e3-cf2a-4216-bbc1-d695c3261a85", "95b1d148-008d-4cfe-a94f-70b3b45660b9", "SuperUser", "SUPERUSER" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "b4ceba25-6673-4b10-aab5-66b4f7d87ab4", "9adf76be-d0ee-4e0b-aeba-e68af28d05c3", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "2f46c1a7-698e-4f51-821f-28308d751c5c");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "b4ceba25-6673-4b10-aab5-66b4f7d87ab4");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "dcc7d3e3-cf2a-4216-bbc1-d695c3261a85");

            migrationBuilder.DropColumn(
                name: "SoftwareType",
                table: "Softwares");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "64df788e-a8a8-4fda-9fc5-c5c1103186ef", "e91fd175-b17f-4375-a85d-c36c8098edcb", "Admin", "ADMIN" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "f78ef613-6166-4332-aaf6-d61568bb544b", "dec8d2c1-b960-495b-aa64-f11c1abed776", "SuperUser", "SUPERUSER" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "da3a40cf-2654-46e7-9e1d-e52603514c10", "b6d2ba11-fb13-4d8d-b27b-5678acfad4b9", "User", "USER" });
        }
    }
}
