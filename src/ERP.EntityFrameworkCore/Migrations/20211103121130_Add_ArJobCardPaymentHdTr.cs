using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_ArJobCardPaymentHdTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArJobCardPaymentHd",
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
                    TenantId = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionNumber = table.Column<string>(maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    ArJobCardHdId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArJobCardPaymentHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArJobCardPaymentHd_ArJobCardHd_ArJobCardHdId",
                        column: x => x.ArJobCardHdId,
                        principalTable: "ArJobCardHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArJobCardPaymentHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArJobCardPaymentTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SourceId = table.Column<long>(nullable: false),
                    SourceTypeLkpId = table.Column<long>(nullable: false),
                    ArJobCardPaymentHdId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArJobCardPaymentTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArJobCardPaymentTr_ArJobCardPaymentHd_ArJobCardPaymentHdId",
                        column: x => x.ArJobCardPaymentHdId,
                        principalTable: "ArJobCardPaymentHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArJobCardPaymentTr_FndLookupValues_SourceTypeLkpId",
                        column: x => x.SourceTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardPaymentHd_ArJobCardHdId",
                table: "ArJobCardPaymentHd",
                column: "ArJobCardHdId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardPaymentHd_StatusLkpId",
                table: "ArJobCardPaymentHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardPaymentTr_ArJobCardPaymentHdId",
                table: "ArJobCardPaymentTr",
                column: "ArJobCardPaymentHdId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardPaymentTr_SourceTypeLkpId",
                table: "ArJobCardPaymentTr",
                column: "SourceTypeLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArJobCardPaymentTr");

            migrationBuilder.DropTable(
                name: "ArJobCardPaymentHd");
        }
    }
}
