using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PmTenantLookups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_CityLkpId",
                table: "PmTenants",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_CountryLkpId",
                table: "PmTenants",
                column: "CountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_NationalityLkpId",
                table: "PmTenants",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_PaymentMethodLkpId",
                table: "PmTenants",
                column: "PaymentMethodLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_StatusLkpId",
                table: "PmTenants",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_CityLkpId",
                table: "PmTenants",
                column: "CityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_CountryLkpId",
                table: "PmTenants",
                column: "CountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_NationalityLkpId",
                table: "PmTenants",
                column: "NationalityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_PaymentMethodLkpId",
                table: "PmTenants",
                column: "PaymentMethodLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_StatusLkpId",
                table: "PmTenants",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_CityLkpId",
                table: "PmTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_CountryLkpId",
                table: "PmTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_NationalityLkpId",
                table: "PmTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_PaymentMethodLkpId",
                table: "PmTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_StatusLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_CityLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_CountryLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_NationalityLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_PaymentMethodLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_StatusLkpId",
                table: "PmTenants");
        }
    }
}
