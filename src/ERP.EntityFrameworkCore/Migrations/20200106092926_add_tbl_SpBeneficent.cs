using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class add_tbl_SpBeneficent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpBeneficent",
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
                    BeneficentNumber = table.Column<string>(maxLength: 30, nullable: false),
                    BeneficentNameAr = table.Column<string>(maxLength: 30, nullable: false),
                    BeneficentNameEN = table.Column<string>(maxLength: 30, nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpBeneficent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArMiscReceiptHeaders_BeneficentId",
                table: "ArMiscReceiptHeaders",
                column: "BeneficentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArMiscReceiptHeaders_SpBeneficent_BeneficentId",
                table: "ArMiscReceiptHeaders",
                column: "BeneficentId",
                principalTable: "SpBeneficent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArMiscReceiptHeaders_SpBeneficent_BeneficentId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropTable(
                name: "SpBeneficent");

            migrationBuilder.DropIndex(
                name: "IX_ArMiscReceiptHeaders_BeneficentId",
                table: "ArMiscReceiptHeaders");
        }
    }
}
