using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class tenantDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantDetailId",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TenantDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    LogoPath = table.Column<string>(maxLength: 100, nullable: true),
                    TenantNameAr = table.Column<string>(maxLength: 100, nullable: true),
                    TenantNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    BoxNo = table.Column<string>(maxLength: 100, nullable: true),
                    Tel = table.Column<string>(maxLength: 100, nullable: true),
                    Fax = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    WebSite = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantDetails_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_TenantDetailId",
                table: "AbpTenants",
                column: "TenantDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantDetails_TenantId",
                table: "TenantDetails",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_TenantDetails_TenantDetailId",
                table: "AbpTenants",
                column: "TenantDetailId",
                principalTable: "TenantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_TenantDetails_TenantDetailId",
                table: "AbpTenants");

            migrationBuilder.DropTable(
                name: "TenantDetails");

            migrationBuilder.DropIndex(
                name: "IX_AbpTenants_TenantDetailId",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "TenantDetailId",
                table: "AbpTenants");
        }
    }
}
