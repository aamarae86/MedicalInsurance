using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScPortalRequestMgrDecision0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefuseForUpdateReason",
                table: "ScPortalRequestStudy",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefuseForUpdateReason",
                table: "ScPortalRequestMgrDecision",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefuseForUpdateReason",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.AlterColumn<string>(
                name: "RefuseForUpdateReason",
                table: "ScPortalRequestStudy",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4000,
                oldNullable: true);
        }
    }
}
