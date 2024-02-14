using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class crmAboutus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrmAboutUs",
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
                    HeaderNameAr = table.Column<string>(maxLength: 200, nullable: false),
                    HeaderNameEN = table.Column<string>(maxLength: 200, nullable: false),
                    ContentAr = table.Column<string>(maxLength: 4000, nullable: true),
                    ContentEn = table.Column<string>(maxLength: 4000, nullable: true),
                    AboutUsFilepath = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmAboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutUSSlider",
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
                    SliderFilepath = table.Column<string>(maxLength: 4000, nullable: true),
                    CrmAboutUsId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUSSlider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUSSlider_CrmAboutUs_CrmAboutUsId",
                        column: x => x.CrmAboutUsId,
                        principalTable: "CrmAboutUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUSSlider_CrmAboutUsId",
                table: "AboutUSSlider",
                column: "CrmAboutUsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUSSlider");

            migrationBuilder.DropTable(
                name: "CrmAboutUs");
        }
    }
}
