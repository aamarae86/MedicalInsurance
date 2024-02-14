using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class GlAccHeaders_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlAccHeaders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    IsHide = table.Column<bool>(nullable: false),
                    AttributeLkpId = table.Column<long>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlAccHeaders_FndLookupValues_AttributeLkpId",
                        column: x => x.AttributeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlAccHeaders_GlAccHeaders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GlAccHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlAccHeaders_AttributeLkpId",
                table: "GlAccHeaders",
                column: "AttributeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_GlAccHeaders_ParentId",
                table: "GlAccHeaders",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlAccHeaders");
        }
    }
}
