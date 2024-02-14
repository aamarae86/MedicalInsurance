using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class TenantDetailMergedToTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseCurrency",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoxNo",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "AbpTenants",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepManagerName",
                table: "AbpTenants",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantNameAr",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantNameEn",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSite",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_AbpTenants_TenantId",
                table: "Currencies");

            //migrationBuilder.DropIndex(
            //    name: "IX_Currencies_TenantId",
            //    table: "Currencies");

            migrationBuilder.DropColumn(
                name: "BaseCurrency",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "BoxNo",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "RepManagerName",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "TenantNameAr",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "TenantNameEn",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "WebSite",
                table: "AbpTenants");
        }
    }
}
