using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RelationToCancellationContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PmCancellationContracts_AccountId",
                table: "PmCancellationContracts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PmCancellationContracts_PmContractId",
                table: "PmCancellationContracts",
                column: "PmContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PmCancellationContracts_StatusLkpId",
                table: "PmCancellationContracts",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmCancellationContracts_GlCodeComDetails_AccountId",
                table: "PmCancellationContracts",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmCancellationContracts_PmContract_PmContractId",
                table: "PmCancellationContracts",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmCancellationContracts_FndLookupValues_StatusLkpId",
                table: "PmCancellationContracts",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmCancellationContracts_GlCodeComDetails_AccountId",
                table: "PmCancellationContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_PmCancellationContracts_PmContract_PmContractId",
                table: "PmCancellationContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_PmCancellationContracts_FndLookupValues_StatusLkpId",
                table: "PmCancellationContracts");

            migrationBuilder.DropIndex(
                name: "IX_PmCancellationContracts_AccountId",
                table: "PmCancellationContracts");

            migrationBuilder.DropIndex(
                name: "IX_PmCancellationContracts_PmContractId",
                table: "PmCancellationContracts");

            migrationBuilder.DropIndex(
                name: "IX_PmCancellationContracts_StatusLkpId",
                table: "PmCancellationContracts");
        }
    }
}
