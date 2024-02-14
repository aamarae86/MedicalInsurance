using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class SpecialGenderAndPassportCountryLookupsInPmTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_PassportCountryLkpId",
                table: "PmTenants",
                column: "PassportCountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_SpecialGenderLkpId",
                table: "PmTenants",
                column: "SpecialGenderLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_PassportCountryLkpId",
                table: "PmTenants",
                column: "PassportCountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_SpecialGenderLkpId",
                table: "PmTenants",
                column: "SpecialGenderLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_PassportCountryLkpId",
                table: "PmTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_SpecialGenderLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_PassportCountryLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_SpecialGenderLkpId",
                table: "PmTenants");
        }
    }
}
