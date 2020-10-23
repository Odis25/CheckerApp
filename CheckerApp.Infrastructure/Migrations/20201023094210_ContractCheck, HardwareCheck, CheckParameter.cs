using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class ContractCheckHardwareCheckCheckParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_networkDevices_Hardwares_NetworkHardwareId",
                table: "networkDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_networkDevices",
                table: "networkDevices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8db499e-cc1f-4890-958b-dcb90202f2db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be84eb31-03c9-40d0-a3f4-e6a0abf6c861");

            migrationBuilder.RenameTable(
                name: "networkDevices",
                newName: "NetworkDevices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkDevices",
                table: "NetworkDevices",
                columns: new[] { "NetworkHardwareId", "Id" });

            migrationBuilder.CreateTable(
                name: "ContractChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    ContractId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractChecks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HardwareId = table.Column<int>(nullable: false),
                    ContractCheckId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareChecks_ContractChecks_ContractCheckId",
                        column: x => x.ContractCheckId,
                        principalTable: "ContractChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HardwareCheckId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Result = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckParameters", x => new { x.HardwareCheckId, x.Id });
                    table.ForeignKey(
                        name: "FK_CheckParameters_HardwareChecks_HardwareCheckId",
                        column: x => x.HardwareCheckId,
                        principalTable: "HardwareChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21ab7334-e0f0-4f49-aa9c-f33c63bc2db1", "ea74b7c8-4ed1-4c66-8666-46925384fab3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9bdc0f53-0061-4e24-95f3-37c87224d664", "71cd4864-8dc8-4c7a-beaa-0a66bb173d7a", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareChecks_ContractCheckId",
                table: "HardwareChecks",
                column: "ContractCheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkDevices_Hardwares_NetworkHardwareId",
                table: "NetworkDevices",
                column: "NetworkHardwareId",
                principalTable: "Hardwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NetworkDevices_Hardwares_NetworkHardwareId",
                table: "NetworkDevices");

            migrationBuilder.DropTable(
                name: "CheckParameters");

            migrationBuilder.DropTable(
                name: "HardwareChecks");

            migrationBuilder.DropTable(
                name: "ContractChecks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkDevices",
                table: "NetworkDevices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21ab7334-e0f0-4f49-aa9c-f33c63bc2db1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bdc0f53-0061-4e24-95f3-37c87224d664");

            migrationBuilder.RenameTable(
                name: "NetworkDevices",
                newName: "networkDevices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_networkDevices",
                table: "networkDevices",
                columns: new[] { "NetworkHardwareId", "Id" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8db499e-cc1f-4890-958b-dcb90202f2db", "d38b210d-9c95-4d7d-9a9c-8462df33ffa4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be84eb31-03c9-40d0-a3f4-e6a0abf6c861", "a61921a4-6b60-4efb-89e3-d587404ed7fa", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_networkDevices_Hardwares_NetworkHardwareId",
                table: "networkDevices",
                column: "NetworkHardwareId",
                principalTable: "Hardwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
