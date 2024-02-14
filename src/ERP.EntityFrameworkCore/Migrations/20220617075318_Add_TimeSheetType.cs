using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_TimeSheetType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TimeSheetTypeId",
                table: "HrPersonTimeSheet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TimeSheetType",
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
                    TimeSheetTypeName = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonTimeSheet_TimeSheetTypeId",
                table: "HrPersonTimeSheet",
                column: "TimeSheetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrPersonTimeSheet_TimeSheetType_TimeSheetTypeId",
                table: "HrPersonTimeSheet",
                column: "TimeSheetTypeId",
                principalTable: "TimeSheetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrPersonTimeSheet_TimeSheetType_TimeSheetTypeId",
                table: "HrPersonTimeSheet");

            migrationBuilder.DropTable(
                name: "TimeSheetType");

            migrationBuilder.DropIndex(
                name: "IX_HrPersonTimeSheet_TimeSheetTypeId",
                table: "HrPersonTimeSheet");

            migrationBuilder.DropColumn(
                name: "TimeSheetTypeId",
                table: "HrPersonTimeSheet");
        }
    }
}
