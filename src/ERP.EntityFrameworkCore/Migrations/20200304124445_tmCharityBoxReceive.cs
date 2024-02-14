using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class tmCharityBoxReceive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmCharityBoxReceive",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    ReceiveDate = table.Column<DateTime>(nullable: false),
                    ReceiveNumber = table.Column<string>(maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    SupplierName = table.Column<string>(maxLength: 200, nullable: false),
                    CharityTypeId = table.Column<long>(nullable: false),
                    NoOfCharityBox = table.Column<long>(nullable: false),
                    AmountCharityBox = table.Column<decimal>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxReceive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxReceive_TmCharityBoxesType_CharityTypeId",
                        column: x => x.CharityTypeId,
                        principalTable: "TmCharityBoxesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxReceive_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxReceive_CharityTypeId",
                table: "TmCharityBoxReceive",
                column: "CharityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxReceive_StatusLkpId",
                table: "TmCharityBoxReceive",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmCharityBoxReceive");
        }
    }
}
