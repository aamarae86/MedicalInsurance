using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fix_GlAccountSelection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GL_ACCOUNT_SELECTION");

            migrationBuilder.CreateTable(
                name: "GlAccountSelection",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    FlexField = table.Column<string>(maxLength: 100, nullable: true),
                    AccType = table.Column<string>(maxLength: 1, nullable: true),
                    YesNo = table.Column<string>(maxLength: 1, nullable: true),
                    FromValue = table.Column<string>(maxLength: 240, nullable: true),
                    ToValue = table.Column<string>(maxLength: 240, nullable: true),
                    Seq = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccountSelection", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlAccountSelection");

            migrationBuilder.CreateTable(
                name: "GL_ACCOUNT_SELECTION",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ACC_TYPE = table.Column<string>(maxLength: 1, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    FLEX_FIELD = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_VALUE = table.Column<string>(maxLength: 240, nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SEQ = table.Column<int>(nullable: true),
                    TO_VALUE = table.Column<string>(maxLength: 240, nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    User_ID = table.Column<long>(nullable: false),
                    YES_NO = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GL_ACCOUNT_SELECTION", x => x.Id);
                });
        }
    }
}
