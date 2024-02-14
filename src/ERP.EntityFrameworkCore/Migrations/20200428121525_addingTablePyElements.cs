using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTablePyElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PyElements",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ElementSerial = table.Column<int>(nullable: false),
                    ElementName = table.Column<string>(maxLength: 200, nullable: true),
                    ElementTypeLkpId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    DebitAccountId = table.Column<long>(nullable: true),
                    CreditAccountId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyElements_GlCodeComDetails_CreditAccountId",
                        column: x => x.CreditAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PyElements_GlCodeComDetails_DebitAccountId",
                        column: x => x.DebitAccountId,
                        principalTable: "GlCodeComDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PyElements_FndLookupValues_ElementTypeLkpId",
                        column: x => x.ElementTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PyElements_CreditAccountId",
                table: "PyElements",
                column: "CreditAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PyElements_DebitAccountId",
                table: "PyElements",
                column: "DebitAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PyElements_ElementTypeLkpId",
                table: "PyElements",
                column: "ElementTypeLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PyElements");
        }
    }
}
