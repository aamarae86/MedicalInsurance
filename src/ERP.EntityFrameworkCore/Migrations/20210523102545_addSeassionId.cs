using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addSeassionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "TenantRenewalHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "TenantRenewalHistories");
        }
    }
}
