using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckerApp.Infrastructure.Migrations
{
    public partial class RenameCheckResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareChecks_ContractChecks_ContractCheckId",
                table: "HardwareChecks");

            migrationBuilder.DropIndex(
                name: "IX_HardwareChecks_ContractCheckId",
                table: "HardwareChecks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21ab7334-e0f0-4f49-aa9c-f33c63bc2db1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bdc0f53-0061-4e24-95f3-37c87224d664");

            migrationBuilder.DropColumn(
                name: "ContractCheckId",
                table: "HardwareChecks");

            migrationBuilder.AddColumn<int>(
                name: "CheckResultId",
                table: "HardwareChecks",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8dd2711c-61a8-4bfa-9362-55952c602c25", "d5701b22-f574-4402-892e-c486e4625b1a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2fbeaf4-ce4c-472b-9d10-772892e62757", "80c0c21f-4a29-4900-9e65-6f47fa2e00d9", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareChecks_CheckResultId",
                table: "HardwareChecks",
                column: "CheckResultId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareChecks_HardwareId",
                table: "HardwareChecks",
                column: "HardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractChecks_ContractId",
                table: "ContractChecks",
                column: "ContractId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareChecks_Hardwares_HardwareId",
                table: "HardwareChecks",
                column: "HardwareId",
                principalTable: "Hardwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractChecks_Contracts_ContractId",
                table: "ContractChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareChecks_ContractChecks_CheckResultId",
                table: "HardwareChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareChecks_Hardwares_HardwareId",
                table: "HardwareChecks");

            migrationBuilder.DropIndex(
                name: "IX_HardwareChecks_CheckResultId",
                table: "HardwareChecks");

            migrationBuilder.DropIndex(
                name: "IX_HardwareChecks_HardwareId",
                table: "HardwareChecks");

            migrationBuilder.DropIndex(
                name: "IX_ContractChecks_ContractId",
                table: "ContractChecks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dd2711c-61a8-4bfa-9362-55952c602c25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2fbeaf4-ce4c-472b-9d10-772892e62757");

            migrationBuilder.DropColumn(
                name: "CheckResultId",
                table: "HardwareChecks");

            migrationBuilder.AddColumn<int>(
                name: "ContractCheckId",
                table: "HardwareChecks",
                type: "int",
                nullable: true);

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
                name: "FK_HardwareChecks_ContractChecks_ContractCheckId",
                table: "HardwareChecks",
                column: "ContractCheckId",
                principalTable: "ContractChecks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
