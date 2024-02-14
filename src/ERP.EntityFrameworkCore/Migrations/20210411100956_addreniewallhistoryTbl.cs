using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addreniewallhistoryTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubEndDate",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TenantRenewalHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Tenant_ID = table.Column<int>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    RenewToUserId = table.Column<long>(nullable: false),
                    RenewalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantRenewalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantRenewalHistories_AbpUsers_RenewToUserId",
                        column: x => x.RenewToUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantRenewalHistories_AbpTenants_Tenant_ID",
                        column: x => x.Tenant_ID,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantRenewalHistories_RenewToUserId",
                table: "TenantRenewalHistories",
                column: "RenewToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantRenewalHistories_Tenant_ID",
                table: "TenantRenewalHistories",
                column: "Tenant_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantRenewalHistories");

            migrationBuilder.DropColumn(
                name: "SubEndDate",
                table: "AbpUsers");
        }
    }
}
