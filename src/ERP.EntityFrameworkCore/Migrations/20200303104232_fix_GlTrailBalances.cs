using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fix_GlTrailBalances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GL_TRIAL_BALANCES");

            migrationBuilder.CreateTable(
                name: "GlTrailBalances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Noa = table.Column<string>(maxLength: 1, nullable: true),
                    AccCode = table.Column<string>(maxLength: 100, nullable: true),
                    ParentCode = table.Column<string>(maxLength: 100, nullable: true),
                    ChildCode = table.Column<string>(maxLength: 100, nullable: true),
                    AccDesc = table.Column<string>(maxLength: 1500, nullable: true),
                    AccAdesc = table.Column<string>(maxLength: 1500, nullable: true),
                    Dr = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Cr = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    ObDr = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    ObCr = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTrailBalances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlTrailBalances");

            migrationBuilder.CreateTable(
                name: "GL_TRIAL_BALANCES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ACC_ADESC = table.Column<string>(maxLength: 1500, nullable: true),
                    ACC_CODE = table.Column<string>(maxLength: 100, nullable: true),
                    ACC_DESC = table.Column<string>(maxLength: 1500, nullable: true),
                    CHILD_CODE = table.Column<string>(maxLength: 100, nullable: true),
                    CR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    NOA = table.Column<string>(maxLength: 1, nullable: true),
                    OB_CR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    OB_DR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    PARENT_CODE = table.Column<string>(maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    User_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GL_TRIAL_BALANCES", x => x.Id);
                });
        }
    }
}
