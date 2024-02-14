using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewCoulmnsPortalUSers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CaseCategoryLkpId",
                table: "PortalUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseNumber",
                table: "PortalUsers",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_CaseCategoryLkpId",
                table: "PortalUsers",
                column: "CaseCategoryLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_FndLookupValues_CaseCategoryLkpId",
                table: "PortalUsers",
                column: "CaseCategoryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_FndLookupValues_CaseCategoryLkpId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_CaseCategoryLkpId",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "CaseCategoryLkpId",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "CaseNumber",
                table: "PortalUsers");
        }
    }
}
