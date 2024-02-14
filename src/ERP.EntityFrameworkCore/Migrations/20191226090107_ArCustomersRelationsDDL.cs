using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArCustomersRelationsDDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ArCustomers_StatusLkpId",
                table: "ArCustomers",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArCustomers_FndLookupValues_StatusLkpId",
                table: "ArCustomers",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArCustomers_FndLookupValues_StatusLkpId",
                table: "ArCustomers");

            migrationBuilder.DropIndex(
                name: "IX_ArCustomers_StatusLkpId",
                table: "ArCustomers");
        }
    }
}
