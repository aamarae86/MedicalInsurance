using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_ArJobCard_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusLkpId",
                table: "ArJobCardHd",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_StatusLkpId",
                table: "ArJobCardHd",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_StatusLkpId",
                table: "ArJobCardHd",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_StatusLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropIndex(
                name: "IX_ArJobCardHd_StatusLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "ArJobCardHd");
        }
    }
}
