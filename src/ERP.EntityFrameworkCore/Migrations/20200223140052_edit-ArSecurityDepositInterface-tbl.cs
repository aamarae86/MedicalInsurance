using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArSecurityDepositInterfacetbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FineAccountId",
                table: "ArSecurityDepositInterface",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArSecurityDepositInterface_ArCustomerId",
                table: "ArSecurityDepositInterface",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArSecurityDepositInterface_FineAccountId",
                table: "ArSecurityDepositInterface",
                column: "FineAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArSecurityDepositInterface_SourceCodeLkpId",
                table: "ArSecurityDepositInterface",
                column: "SourceCodeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArSecurityDepositInterface_StatusLkpId",
                table: "ArSecurityDepositInterface",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_ArCustomers_ArCustomerId",
                table: "ArSecurityDepositInterface",
                column: "ArCustomerId",
                principalTable: "ArCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface",
                column: "FineAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_FndLookupValues_SourceCodeLkpId",
                table: "ArSecurityDepositInterface",
                column: "SourceCodeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArSecurityDepositInterface_FndLookupValues_StatusLkpId",
                table: "ArSecurityDepositInterface",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_ArCustomers_ArCustomerId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_GlCodeComDetails_FineAccountId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_FndLookupValues_SourceCodeLkpId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropForeignKey(
                name: "FK_ArSecurityDepositInterface_FndLookupValues_StatusLkpId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArSecurityDepositInterface_ArCustomerId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArSecurityDepositInterface_FineAccountId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArSecurityDepositInterface_SourceCodeLkpId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.DropIndex(
                name: "IX_ArSecurityDepositInterface_StatusLkpId",
                table: "ArSecurityDepositInterface");

            migrationBuilder.AlterColumn<long>(
                name: "FineAccountId",
                table: "ArSecurityDepositInterface",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}
