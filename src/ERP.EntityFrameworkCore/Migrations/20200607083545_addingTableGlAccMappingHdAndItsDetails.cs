using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTableGlAccMappingHdAndItsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlAccMappingHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MapName = table.Column<string>(maxLength: 200, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccMappingHd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlAccMappingTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    GlAccMappingHdId = table.Column<long>(nullable: false),
                    TrName = table.Column<string>(maxLength: 200, nullable: true),
                    TrNo = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccMappingTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlAccMappingTr_GlAccMappingHd_GlAccMappingHdId",
                        column: x => x.GlAccMappingHdId,
                        principalTable: "GlAccMappingHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlAccMappingTrDtl",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    GlAccMappingTrId = table.Column<long>(nullable: false),
                    TypeLkpId = table.Column<long>(nullable: true),
                    FromAccId = table.Column<long>(nullable: true),
                    ToAccId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccMappingTrDtl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlAccMappingTrDtl_GlAccounts_FromAccId",
                        column: x => x.FromAccId,
                        principalTable: "GlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GlAccMappingTrDtl_GlAccMappingTr_GlAccMappingTrId",
                        column: x => x.GlAccMappingTrId,
                        principalTable: "GlAccMappingTr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlAccMappingTrDtl_GlAccounts_ToAccId",
                        column: x => x.ToAccId,
                        principalTable: "GlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GlAccMappingTrDtl_FndLookupValues_TypeLkpId",
                        column: x => x.TypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlAccMappingTr_GlAccMappingHdId",
                table: "GlAccMappingTr",
                column: "GlAccMappingHdId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccMappingTrDtl_FromAccId",
                table: "GlAccMappingTrDtl",
                column: "FromAccId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccMappingTrDtl_GlAccMappingTrId",
                table: "GlAccMappingTrDtl",
                column: "GlAccMappingTrId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccMappingTrDtl_ToAccId",
                table: "GlAccMappingTrDtl",
                column: "ToAccId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccMappingTrDtl_TypeLkpId",
                table: "GlAccMappingTrDtl",
                column: "TypeLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlAccMappingTrDtl");

            migrationBuilder.DropTable(
                name: "GlAccMappingTr");

            migrationBuilder.DropTable(
                name: "GlAccMappingHd");
        }
    }
}
