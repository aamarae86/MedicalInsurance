using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class updatingspcontracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeductedLkpId",
                table: "SpContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentTypeLkpId",
                table: "SpContracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpContracts_DeductedLkpId",
                table: "SpContracts",
                column: "DeductedLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpContracts_PaymentTypeLkpId",
                table: "SpContracts",
                column: "PaymentTypeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpContracts_FndLookupValues_DeductedLkpId",
                table: "SpContracts",
                column: "DeductedLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpContracts_FndLookupValues_PaymentTypeLkpId",
                table: "SpContracts",
                column: "PaymentTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpContracts_FndLookupValues_DeductedLkpId",
                table: "SpContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_SpContracts_FndLookupValues_PaymentTypeLkpId",
                table: "SpContracts");

            migrationBuilder.DropIndex(
                name: "IX_SpContracts_DeductedLkpId",
                table: "SpContracts");

            migrationBuilder.DropIndex(
                name: "IX_SpContracts_PaymentTypeLkpId",
                table: "SpContracts");

            migrationBuilder.DropColumn(
                name: "DeductedLkpId",
                table: "SpContracts");

            migrationBuilder.DropColumn(
                name: "PaymentTypeLkpId",
                table: "SpContracts");
        }
    }
}
