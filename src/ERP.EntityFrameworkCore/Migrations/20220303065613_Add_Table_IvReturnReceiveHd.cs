using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_Table_IvReturnReceiveHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvReturnReceiveHd",
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
                    IvReceiveHdId = table.Column<long>(nullable: false),
                    IvReturnReceiveNumber = table.Column<string>(maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    IvReturnReceiveDate = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvReturnReceiveHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvReturnReceiveHd_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReturnReceiveHd_IvReceiveHd_IvReceiveHdId",
                        column: x => x.IvReceiveHdId,
                        principalTable: "IvReceiveHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IvReturnReceiveHd_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IvReturnReceiveTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IvReturnReceiveHdId = table.Column<long>(nullable: false),
                    IvReceiveTrId = table.Column<long>(nullable: false),
                    RQty = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    TaxPercentageLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvReturnReceiveTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvReturnReceiveTr_IvReceiveTr_IvReceiveTrId",
                        column: x => x.IvReceiveTrId,
                        principalTable: "IvReceiveTr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IvReturnReceiveTr_IvReturnReceiveHd_IvReturnReceiveHdId",
                        column: x => x.IvReturnReceiveHdId,
                        principalTable: "IvReturnReceiveHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IvReturnReceiveTr_FndLookupValues_TaxPercentageLkpId",
                        column: x => x.TaxPercentageLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveHd_CurrencyId",
                table: "IvReturnReceiveHd",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveHd_IvReceiveHdId",
                table: "IvReturnReceiveHd",
                column: "IvReceiveHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveHd_StatusLkpId",
                table: "IvReturnReceiveHd",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveTr_IvReceiveTrId",
                table: "IvReturnReceiveTr",
                column: "IvReceiveTrId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveTr_IvReturnReceiveHdId",
                table: "IvReturnReceiveTr",
                column: "IvReturnReceiveHdId");

            migrationBuilder.CreateIndex(
                name: "IX_IvReturnReceiveTr_TaxPercentageLkpId",
                table: "IvReturnReceiveTr",
                column: "TaxPercentageLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvReturnReceiveTr");

            migrationBuilder.DropTable(
                name: "IvReturnReceiveHd");
        }
    }
}
