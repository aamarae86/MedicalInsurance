using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Update_HrpaperRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HrPaperRequestId",
                table: "HrPaperRequestAttachment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_HrPaperRequestAttachment_HrPaperRequestId",
                table: "HrPaperRequestAttachment",
                column: "HrPaperRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrPaperRequestAttachment_HrPaperRequest_HrPaperRequestId",
                table: "HrPaperRequestAttachment",
                column: "HrPaperRequestId",
                principalTable: "HrPaperRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrPaperRequestAttachment_HrPaperRequest_HrPaperRequestId",
                table: "HrPaperRequestAttachment");

            migrationBuilder.DropIndex(
                name: "IX_HrPaperRequestAttachment_HrPaperRequestId",
                table: "HrPaperRequestAttachment");

            migrationBuilder.DropColumn(
                name: "HrPaperRequestId",
                table: "HrPaperRequestAttachment");
        }
    }
}
