using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class RenameCheckResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractChecks_Contracts_ContractId",
                table: "ContractChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareChecks_ContractChecks_CheckResultId",
                table: "HardwareChecks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractChecks",
                table: "ContractChecks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dd2711c-61a8-4bfa-9362-55952c602c25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2fbeaf4-ce4c-472b-9d10-772892e62757");

            migrationBuilder.RenameTable(
                name: "ContractChecks",
                newName: "CheckResults");

            migrationBuilder.RenameIndex(
                name: "IX_ContractChecks_ContractId",
                table: "CheckResults",
                newName: "IX_CheckResults_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckResults",
                table: "CheckResults",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b9b9f24-563f-4b8c-97c5-673d27d93f50", "453be366-205f-458b-bfa7-1b69b6ddd8d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08e7ad60-6130-4c2b-9686-1804794e241d", "b6ad5952-f927-48af-bef3-32d01582d3fa", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_CheckResults_Contracts_ContractId",
                table: "CheckResults",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareChecks_CheckResults_CheckResultId",
                table: "HardwareChecks",
                column: "CheckResultId",
                principalTable: "CheckResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckResults_Contracts_ContractId",
                table: "CheckResults");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareChecks_CheckResults_CheckResultId",
                table: "HardwareChecks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckResults",
                table: "CheckResults");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08e7ad60-6130-4c2b-9686-1804794e241d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b9b9f24-563f-4b8c-97c5-673d27d93f50");

            migrationBuilder.RenameTable(
                name: "CheckResults",
                newName: "ContractChecks");

            migrationBuilder.RenameIndex(
                name: "IX_CheckResults_ContractId",
                table: "ContractChecks",
                newName: "IX_ContractChecks_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractChecks",
                table: "ContractChecks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8dd2711c-61a8-4bfa-9362-55952c602c25", "d5701b22-f574-4402-892e-c486e4625b1a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2fbeaf4-ce4c-472b-9d10-772892e62757", "80c0c21f-4a29-4900-9e65-6f47fa2e00d9", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContractChecks_Contracts_ContractId",
                table: "ContractChecks",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareChecks_ContractChecks_CheckResultId",
                table: "HardwareChecks",
                column: "CheckResultId",
                principalTable: "ContractChecks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
