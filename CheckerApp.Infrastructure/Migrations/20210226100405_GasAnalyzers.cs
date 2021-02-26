using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class GasAnalyzers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52bce6fe-ede1-4fb5-a549-70d6a6f7d9d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85a40054-0071-4d1c-ae45-129aee1bbcd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5440bc3-dea9-4804-9d09-bab7a36925f2");

            migrationBuilder.CreateTable(
                name: "GasAnalyzers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    EU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignalType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasAnalyzers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasAnalyzers_Hardwares_Id",
                        column: x => x.Id,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasAnalyzers");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5440bc3-dea9-4804-9d09-bab7a36925f2", "aea9c7ff-90c7-4129-bb1f-74108a391eda", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85a40054-0071-4d1c-ae45-129aee1bbcd8", "459f6553-727e-4ce9-babf-e23fc810d529", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52bce6fe-ede1-4fb5-a549-70d6a6f7d9d7", "b0db9659-dfe4-409b-979c-400f330bc584", "User", "USER" });
        }
    }
}
