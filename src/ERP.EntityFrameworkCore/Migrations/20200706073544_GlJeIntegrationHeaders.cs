using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class GlJeIntegrationHeaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SpContractAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SpCasesAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SpBeneficentAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "ScPortalRequestStudyAttachment",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PortalUserAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmTenantsAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmPropertiesAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmContractAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "GlJeIntegrationHeaders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PostUserId = table.Column<long>(nullable: true),
                    PostTime = table.Column<DateTime>(nullable: true),
                    UnPostUserId = table.Column<long>(nullable: true),
                    UnPostTime = table.Column<DateTime>(nullable: true),
                    JeName = table.Column<string>(maxLength: 500, nullable: false),
                    GlJeIntegrationNumber = table.Column<string>(maxLength: 100, nullable: false),
                    GlJeIntegrationDate = table.Column<DateTime>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GlJeIntegrationNotes = table.Column<string>(maxLength: 4000, nullable: true),
                    GlJeIntegrationSourceNo = table.Column<string>(maxLength: 20, nullable: true),
                    PeriodId = table.Column<long>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: true),
                    GlJeIntegrationSourceLkpId = table.Column<long>(nullable: true),
                    GlJeIntegrationSourceId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlJeIntegrationHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationHeaders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationHeaders_FndLookupValues_GlJeIntegrationSourceLkpId",
                        column: x => x.GlJeIntegrationSourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationHeaders_GlPeriodsDetails_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "GlPeriodsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationHeaders_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlJeIntegrationLines",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GlJeIntegrationHeaderId = table.Column<long>(nullable: false),
                    JeIntegrationLineTypeLkpId = table.Column<long>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    ArCustomerId = table.Column<long>(nullable: true),
                    ApVendorId = table.Column<long>(nullable: true),
                    JeIntegrationLineNotes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlJeIntegrationLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationLines_GlCodeComDetails_AccountId",
                        column: x => x.AccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationLines_ApVendors_ApVendorId",
                        column: x => x.ApVendorId,
                        principalTable: "ApVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationLines_ArCustomers_ArCustomerId",
                        column: x => x.ArCustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationLines_GlJeIntegrationHeaders_GlJeIntegrationHeaderId",
                        column: x => x.GlJeIntegrationHeaderId,
                        principalTable: "GlJeIntegrationHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlJeIntegrationLines_FndLookupValues_JeIntegrationLineTypeLkpId",
                        column: x => x.JeIntegrationLineTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationHeaders_CurrencyId",
                table: "GlJeIntegrationHeaders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationHeaders_GlJeIntegrationSourceLkpId",
                table: "GlJeIntegrationHeaders",
                column: "GlJeIntegrationSourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationHeaders_PeriodId",
                table: "GlJeIntegrationHeaders",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationHeaders_StatusLkpId",
                table: "GlJeIntegrationHeaders",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationLines_AccountId",
                table: "GlJeIntegrationLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationLines_ApVendorId",
                table: "GlJeIntegrationLines",
                column: "ApVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationLines_ArCustomerId",
                table: "GlJeIntegrationLines",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationLines_GlJeIntegrationHeaderId",
                table: "GlJeIntegrationLines",
                column: "GlJeIntegrationHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_GlJeIntegrationLines_JeIntegrationLineTypeLkpId",
                table: "GlJeIntegrationLines",
                column: "JeIntegrationLineTypeLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlJeIntegrationLines");

            migrationBuilder.DropTable(
                name: "GlJeIntegrationHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SpContractAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SpCasesAttachments",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SpBeneficentAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "ScPortalRequestStudyAttachment",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PortalUserAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmTenantsAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmPropertiesAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmContractAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
