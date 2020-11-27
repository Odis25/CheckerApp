using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class ProjectNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f187262-07a3-43d9-9a91-0e4b31118827");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a22f5136-ae27-45ba-b317-93bce7763756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c08cf1ad-7ade-4cba-90ea-1b3570a10cf7");

            migrationBuilder.AddColumn<string>(
                name: "ProjectNumber",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b7f3480-b5d5-4939-9c09-53386fa73733", "4e123b74-3a98-494c-8e52-487f4c86a7e2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12008f5a-9f4d-4ebc-be3d-7cceba247413", "6e1f2bc4-66ee-401e-a482-db0bc835ea72", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec5cb292-9cd8-4171-8b5e-b642cbb95826", "d90555b6-eb4a-4284-aa80-7337e0b93792", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12008f5a-9f4d-4ebc-be3d-7cceba247413");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b7f3480-b5d5-4939-9c09-53386fa73733");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec5cb292-9cd8-4171-8b5e-b642cbb95826");

            migrationBuilder.DropColumn(
                name: "ProjectNumber",
                table: "Contracts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c08cf1ad-7ade-4cba-90ea-1b3570a10cf7", "c8888c17-c053-44a6-b90c-afa7ecb5b7bf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a22f5136-ae27-45ba-b317-93bce7763756", "7fb39ebd-163e-4810-b6f9-e53f04cd872c", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f187262-07a3-43d9-9a91-0e4b31118827", "2628f5c7-63e0-464b-8a67-9240619e4d63", "User", "USER" });
        }
    }
}
