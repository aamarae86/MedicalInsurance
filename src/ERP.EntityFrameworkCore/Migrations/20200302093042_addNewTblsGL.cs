using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewTblsGL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GL_ACCOUNT_SELECTION",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    FLEX_FIELD = table.Column<string>(maxLength: 100, nullable: true),
                    ACC_TYPE = table.Column<string>(maxLength: 1, nullable: true),
                    YES_NO = table.Column<string>(maxLength: 1, nullable: true),
                    FROM_VALUE = table.Column<string>(maxLength: 240, nullable: true),
                    TO_VALUE = table.Column<string>(maxLength: 240, nullable: true),
                    SEQ = table.Column<int>(nullable: true),
                    User_ID = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GL_ACCOUNT_SELECTION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GL_TRIAL_BALANCES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    NOA = table.Column<string>(maxLength: 1, nullable: true),
                    ACC_CODE = table.Column<string>(maxLength: 100, nullable: true),
                    PARENT_CODE = table.Column<string>(maxLength: 100, nullable: true),
                    CHILD_CODE = table.Column<string>(maxLength: 100, nullable: true),
                    ACC_DESC = table.Column<string>(maxLength: 1500, nullable: true),
                    ACC_ADESC = table.Column<string>(maxLength: 1500, nullable: true),
                    DR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    OB_DR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    OB_CR = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    User_ID = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GL_TRIAL_BALANCES", x => x.Id);
                });

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GL_ACCOUNT_SELECTION");

            migrationBuilder.DropTable(
                name: "GL_TRIAL_BALANCES");

        }
    }
}
