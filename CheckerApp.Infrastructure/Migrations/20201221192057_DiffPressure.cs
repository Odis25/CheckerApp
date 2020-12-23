using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class DiffPressure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DiffPressures",
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
                    table.PrimaryKey("PK_DiffPressures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiffPressures_Hardwares_Id",
                        column: x => x.Id,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiffPressures");

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
    }
}
