using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class Software : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f499c27-f533-4a6a-9da7-404b2993ce83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b3b144b-418b-49af-9eb0-1a2061a0b0bf");

            migrationBuilder.AddColumn<bool>(
                name: "HasRAID",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyboard",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyboardSN",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Monitor",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonitorSN",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mouse",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MouseSN",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OS",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductKeyOS",
                table: "Hardwares",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NetworkAdapters",
                columns: table => new
                {
                    ARMId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(nullable: true),
                    MacAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkAdapters", x => new { x.ARMId, x.Id });
                    table.ForeignKey(
                        name: "FK_NetworkAdapters_Hardwares_ARMId",
                        column: x => x.ARMId,
                        principalTable: "Hardwares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    SoftwareType = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Softwares_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95a2a7e7-8365-4f35-a523-863d105eabca", "e97ef188-29a7-4262-8a1e-335f5890bc9f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59ed7ef6-aba9-4ea1-aceb-97e71bd3bba2", "aa110c66-6f7e-4ed1-bb98-1c453142da6a", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_ContractId",
                table: "Softwares",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkAdapters");

            migrationBuilder.DropTable(
                name: "Softwares");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59ed7ef6-aba9-4ea1-aceb-97e71bd3bba2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a2a7e7-8365-4f35-a523-863d105eabca");

            migrationBuilder.DropColumn(
                name: "HasRAID",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "Keyboard",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "KeyboardSN",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "Monitor",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "MonitorSN",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "Mouse",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "MouseSN",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "OS",
                table: "Hardwares");

            migrationBuilder.DropColumn(
                name: "ProductKeyOS",
                table: "Hardwares");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b3b144b-418b-49af-9eb0-1a2061a0b0bf", "adf9dccd-4162-48ae-be78-38dfd80318f9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f499c27-f533-4a6a-9da7-404b2993ce83", "eca627b2-7f17-428c-912e-500042fd8319", "User", "USER" });
        }
    }
}
