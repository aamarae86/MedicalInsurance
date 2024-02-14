using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addtblFndSpell2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FndSpell",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OnesAr = table.Column<string>(maxLength: 30, nullable: false),
                    OnesEn = table.Column<string>(maxLength: 30, nullable: false),
                    TensAr = table.Column<string>(maxLength: 30, nullable: true),
                    TensEn = table.Column<string>(maxLength: 30, nullable: true),
                    HunsAr = table.Column<string>(maxLength: 30, nullable: true),
                    HunsEn = table.Column<string>(maxLength: 30, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FndSpell", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FndSpell");
        }
    }
}
