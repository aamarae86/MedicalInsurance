using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class CodeComInStoreIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "IvStoreIssueHd",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "IvStoreIssueHd");
        }
    }
}
