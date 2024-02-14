using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class relationToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PmTerminateContracts_PmContractId",
                table: "PmTerminateContracts",
                column: "PmContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PmTerminateContracts_StatusLkpId",
                table: "PmTerminateContracts",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmTerminateContracts_PmContract_PmContractId",
                table: "PmTerminateContracts",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTerminateContracts_FndLookupValues_StatusLkpId",
                table: "PmTerminateContracts",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmTerminateContracts_PmContract_PmContractId",
                table: "PmTerminateContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTerminateContracts_FndLookupValues_StatusLkpId",
                table: "PmTerminateContracts");

            migrationBuilder.DropIndex(
                name: "IX_PmTerminateContracts_PmContractId",
                table: "PmTerminateContracts");

            migrationBuilder.DropIndex(
                name: "IX_PmTerminateContracts_StatusLkpId",
                table: "PmTerminateContracts");
        }
    }
}
