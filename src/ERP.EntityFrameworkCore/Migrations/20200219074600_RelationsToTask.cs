using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RelationsToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrancyId",
                table: "ArInvoiceHd",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PmTenants_MaritalStatusLkpId",
            //    table: "PmTenants",
            //    column: "MaritalStatusLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PmTenants_PassportCountryLkpId",
            //    table: "PmTenants",
            //    column: "PassportCountryLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PmTenants_SpecialGenderLkpId",
            //    table: "PmTenants",
            //    column: "SpecialGenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceTr_AccountId",
                table: "ArInvoiceTr",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceHd_ArCustomerId",
                table: "ArInvoiceHd",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceHd_CurrancyId",
                table: "ArInvoiceHd",
                column: "CurrancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceHd_SourceLkpId",
                table: "ArInvoiceHd",
                column: "SourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceHd_StatusLkpId",
                table: "ArInvoiceHd",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArInvoiceHd_ArCustomers_ArCustomerId",
                table: "ArInvoiceHd",
                column: "ArCustomerId",
                principalTable: "ArCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArInvoiceHd_Currencies_CurrancyId",
                table: "ArInvoiceHd",
                column: "CurrancyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArInvoiceHd_FndLookupValues_SourceLkpId",
                table: "ArInvoiceHd",
                column: "SourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArInvoiceHd_FndLookupValues_StatusLkpId",
                table: "ArInvoiceHd",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArInvoiceTr_GlCodeComDetails_AccountId",
                table: "ArInvoiceTr",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_MaritalStatusLkpId",
            //    table: "PmTenants",
            //    column: "MaritalStatusLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_PassportCountryLkpId",
            //    table: "PmTenants",
            //    column: "PassportCountryLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_SpecialGenderLkpId",
            //    table: "PmTenants",
            //    column: "SpecialGenderLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArInvoiceHd_ArCustomers_ArCustomerId",
                table: "ArInvoiceHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArInvoiceHd_Currencies_CurrancyId",
                table: "ArInvoiceHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArInvoiceHd_FndLookupValues_SourceLkpId",
                table: "ArInvoiceHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArInvoiceHd_FndLookupValues_StatusLkpId",
                table: "ArInvoiceHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArInvoiceTr_GlCodeComDetails_AccountId",
                table: "ArInvoiceTr");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_MaritalStatusLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_PassportCountryLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PmTenants_FndLookupValues_SpecialGenderLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_PmTenants_MaritalStatusLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_PmTenants_PassportCountryLkpId",
            //    table: "PmTenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_PmTenants_SpecialGenderLkpId",
            //    table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_ArInvoiceTr_AccountId",
                table: "ArInvoiceTr");

            migrationBuilder.DropIndex(
                name: "IX_ArInvoiceHd_ArCustomerId",
                table: "ArInvoiceHd");

            migrationBuilder.DropIndex(
                name: "IX_ArInvoiceHd_CurrancyId",
                table: "ArInvoiceHd");

            migrationBuilder.DropIndex(
                name: "IX_ArInvoiceHd_SourceLkpId",
                table: "ArInvoiceHd");

            migrationBuilder.DropIndex(
                name: "IX_ArInvoiceHd_StatusLkpId",
                table: "ArInvoiceHd");

            migrationBuilder.AlterColumn<long>(
                name: "CurrancyId",
                table: "ArInvoiceHd",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
