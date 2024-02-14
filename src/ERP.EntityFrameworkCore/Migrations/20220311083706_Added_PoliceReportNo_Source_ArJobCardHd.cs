using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Added_PoliceReportNo_Source_ArJobCardHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PoliceReportNo",
                table: "ArJobCardHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PoliceReportSourceLkpId",
                table: "ArJobCardHd",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_PoliceReportSourceLkpId",
                table: "ArJobCardHd",
                column: "PoliceReportSourceLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_PoliceReportSourceLkpId",
                table: "ArJobCardHd",
                column: "PoliceReportSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_PoliceReportSourceLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropIndex(
                name: "IX_ArJobCardHd_PoliceReportSourceLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropColumn(
                name: "PoliceReportNo",
                table: "ArJobCardHd");

            migrationBuilder.DropColumn(
                name: "PoliceReportSourceLkpId",
                table: "ArJobCardHd");
        }
    }
}
