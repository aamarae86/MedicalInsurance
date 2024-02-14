using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArInvoiceHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArInvoiceHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    HdInvoiceNo = table.Column<string>(maxLength: 30, nullable: true),
                    HdDate = table.Column<DateTime>(nullable: true),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    CurrancyId = table.Column<long>(nullable: true),
                    CurrancyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ArCustomerId = table.Column<long>(nullable: true),
                    SourceLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    SourceNo = table.Column<string>(maxLength: 30, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArInvoiceHd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArInvoiceTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ArInvoiceHdId = table.Column<long>(nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArInvoiceTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArInvoiceTr_ArInvoiceHd_ArInvoiceHdId",
                        column: x => x.ArInvoiceHdId,
                        principalTable: "ArInvoiceHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArInvoiceTr_ArInvoiceHdId",
                table: "ArInvoiceTr",
                column: "ArInvoiceHdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArInvoiceTr");

            migrationBuilder.DropTable(
                name: "ArInvoiceHd");
        }
    }
}
