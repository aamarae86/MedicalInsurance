using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class tenantBaseCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_AbpTenants_TenantId",
                table: "Currencies");

            //migrationBuilder.DropIndex(
            //    name: "IX_Currencies_TenantId",
            //    table: "Currencies");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_BaseCurrency",
                table: "AbpTenants",
                column: "BaseCurrency");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_Currencies_BaseCurrency",
                table: "AbpTenants",
                column: "BaseCurrency",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_Currencies_BaseCurrency",
                table: "AbpTenants");

            migrationBuilder.DropIndex(
                name: "IX_AbpTenants_BaseCurrency",
                table: "AbpTenants");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Currencies_TenantId",
            //    table: "Currencies",
            //    column: "TenantId",
            //    unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_AbpTenants_TenantId",
                table: "Currencies",
                column: "TenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
