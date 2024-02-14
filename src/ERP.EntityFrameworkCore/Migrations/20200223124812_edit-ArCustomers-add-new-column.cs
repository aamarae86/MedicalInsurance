using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editArCustomersaddnewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SourceCodeLkpId",
                table: "ArCustomers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "ArCustomers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArCustomers_SourceCodeLkpId",
                table: "ArCustomers",
                column: "SourceCodeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArCustomers_FndLookupValues_SourceCodeLkpId",
                table: "ArCustomers",
                column: "SourceCodeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArCustomers_FndLookupValues_SourceCodeLkpId",
                table: "ArCustomers");

            migrationBuilder.DropIndex(
                name: "IX_ArCustomers_SourceCodeLkpId",
                table: "ArCustomers");

            migrationBuilder.DropColumn(
                name: "SourceCodeLkpId",
                table: "ArCustomers");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "ArCustomers");
        }
    }
}
