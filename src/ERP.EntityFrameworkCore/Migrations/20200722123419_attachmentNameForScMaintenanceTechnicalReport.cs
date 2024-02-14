using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class attachmentNameForScMaintenanceTechnicalReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttachmentName",
                table: "ScMaintenanceTechnicalReportAttachments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentName",
                table: "ScMaintenanceTechnicalReportAttachments");
        }
    }
}
