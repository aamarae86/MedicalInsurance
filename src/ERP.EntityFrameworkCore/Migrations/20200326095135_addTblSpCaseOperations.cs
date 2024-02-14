using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addTblSpCaseOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpCaseOperations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    ReasonLkpId = table.Column<long>(nullable: false),
                    OperationTypeLkpId = table.Column<long>(nullable: false),
                    SpContractDetailsId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpCaseOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpCaseOperations_FndLookupValues_OperationTypeLkpId",
                        column: x => x.OperationTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpCaseOperations_FndLookupValues_ReasonLkpId",
                        column: x => x.ReasonLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpCaseOperations_SpContractDetails_SpContractDetailsId",
                        column: x => x.SpContractDetailsId,
                        principalTable: "SpContractDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseOperations_OperationTypeLkpId",
                table: "SpCaseOperations",
                column: "OperationTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseOperations_ReasonLkpId",
                table: "SpCaseOperations",
                column: "ReasonLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpCaseOperations_SpContractDetailsId",
                table: "SpCaseOperations",
                column: "SpContractDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpCaseOperations");
        }
    }
}
