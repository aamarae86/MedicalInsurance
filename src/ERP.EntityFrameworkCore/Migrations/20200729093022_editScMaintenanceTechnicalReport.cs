using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScMaintenanceTechnicalReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ScCommitteeDetailId",
                table: "ScMaintenanceTechnicalReport",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceTechnicalReport_ScCommitteeDetailId",
                table: "ScMaintenanceTechnicalReport",
                column: "ScCommitteeDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScMaintenanceTechnicalReport_ScCommitteeDetails_ScCommitteeDetailId",
                table: "ScMaintenanceTechnicalReport",
                column: "ScCommitteeDetailId",
                principalTable: "ScCommitteeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScMaintenanceTechnicalReport_ScCommitteeDetails_ScCommitteeDetailId",
                table: "ScMaintenanceTechnicalReport");

            migrationBuilder.DropIndex(
                name: "IX_ScMaintenanceTechnicalReport_ScCommitteeDetailId",
                table: "ScMaintenanceTechnicalReport");

            migrationBuilder.DropColumn(
                name: "ScCommitteeDetailId",
                table: "ScMaintenanceTechnicalReport");
        }
    }
}
