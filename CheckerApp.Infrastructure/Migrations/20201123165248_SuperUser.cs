using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class SuperUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b16d0d32-a9fc-4952-b0cf-c7a1ebbc227c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d06d9ea3-9fa9-48f4-904f-6d6baaf3d414");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d06d9ea3-9fa9-48f4-904f-6d6baaf3d414", "c0933787-d7f2-4d0a-aac4-d030bd1864ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b16d0d32-a9fc-4952-b0cf-c7a1ebbc227c", "4511ef38-5268-4b8b-aa86-8a58f36385c9", "User", "USER" });
        }
    }
}
