using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_HrPaperRequestAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrPaperRequest_HrPersons_HrPersonId",
                table: "HrPaperRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_HrPaperRequest_PaperReqType_PaperReqTypeId",
                table: "HrPaperRequest");

            migrationBuilder.DropIndex(
                name: "IX_HrPaperRequest_HrPersonId",
                table: "HrPaperRequest");

            migrationBuilder.DropIndex(
                name: "IX_HrPaperRequest_PaperReqTypeId",
                table: "HrPaperRequest");

            migrationBuilder.DropColumn(
                name: "HrPersonId",
                table: "HrPaperRequest");

            migrationBuilder.DropColumn(
                name: "PaperReqTypeId",
                table: "HrPaperRequest");

            migrationBuilder.RenameColumn(
                name: "ReqDetails",
                table: "HrPaperRequest",
                newName: "Notes");

            migrationBuilder.CreateTable(
                name: "HrPaperRequestAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(maxLength: 2000, nullable: true),
                    HrPersonId = table.Column<long>(nullable: false),
                    PaperReqTypeId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrPaperRequestAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPaperRequestAttachment_HrPersons_HrPersonId",
                        column: x => x.HrPersonId,
                        principalTable: "HrPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrPaperRequestAttachment_PaperReqType_PaperReqTypeId",
                        column: x => x.PaperReqTypeId,
                        principalTable: "PaperReqType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrPaperRequestAttachment_HrPersonId",
                table: "HrPaperRequestAttachment",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPaperRequestAttachment_PaperReqTypeId",
                table: "HrPaperRequestAttachment",
                column: "PaperReqTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrPaperRequestAttachment");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "HrPaperRequest",
                newName: "ReqDetails");

            migrationBuilder.AddColumn<long>(
                name: "HrPersonId",
                table: "HrPaperRequest",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PaperReqTypeId",
                table: "HrPaperRequest",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_HrPaperRequest_HrPersonId",
                table: "HrPaperRequest",
                column: "HrPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrPaperRequest_PaperReqTypeId",
                table: "HrPaperRequest",
                column: "PaperReqTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrPaperRequest_HrPersons_HrPersonId",
                table: "HrPaperRequest",
                column: "HrPersonId",
                principalTable: "HrPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HrPaperRequest_PaperReqType_PaperReqTypeId",
                table: "HrPaperRequest",
                column: "PaperReqTypeId",
                principalTable: "PaperReqType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
