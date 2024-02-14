using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editAffliateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AffliateAccount_BankLkpId",
                table: "AffliateAccount",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_AffliateAccount_CountryLkpId",
                table: "AffliateAccount",
                column: "CountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_AffliateAccount_LanguageLkpId",
                table: "AffliateAccount",
                column: "LanguageLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_AffliateAccount_FndLookupValues_BankLkpId",
                table: "AffliateAccount",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffliateAccount_FndLookupValues_CountryLkpId",
                table: "AffliateAccount",
                column: "CountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffliateAccount_FndLookupValues_LanguageLkpId",
                table: "AffliateAccount",
                column: "LanguageLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AffliateAccount_FndLookupValues_BankLkpId",
                table: "AffliateAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_AffliateAccount_FndLookupValues_CountryLkpId",
                table: "AffliateAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_AffliateAccount_FndLookupValues_LanguageLkpId",
                table: "AffliateAccount");

            migrationBuilder.DropIndex(
                name: "IX_AffliateAccount_BankLkpId",
                table: "AffliateAccount");

            migrationBuilder.DropIndex(
                name: "IX_AffliateAccount_CountryLkpId",
                table: "AffliateAccount");

            migrationBuilder.DropIndex(
                name: "IX_AffliateAccount_LanguageLkpId",
                table: "AffliateAccount");
        }
    }
}
