using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addScFndProtalAttachmentSettingtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScFndProtalAttachmentSetting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentNameAr = table.Column<string>(maxLength: 200, nullable: false),
                    AttachmentNameEn = table.Column<string>(maxLength: 200, nullable: false),
                    RequestTypeId = table.Column<long>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScFndProtalAttachmentSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScFndProtalAttachmentSetting_ScFndPortalIntervalSetting_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "ScFndPortalIntervalSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScFndProtalAttachmentSetting_RequestTypeId",
                table: "ScFndProtalAttachmentSetting",
                column: "RequestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScFndProtalAttachmentSetting");
        }
    }
}
