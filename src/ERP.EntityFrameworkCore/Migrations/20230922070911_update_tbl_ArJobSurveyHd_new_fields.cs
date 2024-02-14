using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class update_tbl_ArJobSurveyHd_new_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ArCustomerId",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute1",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute2",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute3",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute4",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "ArJobSurveyHd",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "ArJobSurveyHd",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedAmount",
                table: "ArJobSurveyHd",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "JobTypeLkpId",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LabourCharges",
                table: "ArJobSurveyHd",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VehicleColorLkpId",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VehicleEmirateLkpId",
                table: "ArJobSurveyHd",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyHd_ArCustomerId",
                table: "ArJobSurveyHd",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyHd_JobTypeLkpId",
                table: "ArJobSurveyHd",
                column: "JobTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyHd_VehicleColorLkpId",
                table: "ArJobSurveyHd",
                column: "VehicleColorLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyHd_VehicleEmirateLkpId",
                table: "ArJobSurveyHd",
                column: "VehicleEmirateLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobSurveyHd_ArCustomers_ArCustomerId",
                table: "ArJobSurveyHd",
                column: "ArCustomerId",
                principalTable: "ArCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobSurveyHd_FndLookupValues_JobTypeLkpId",
                table: "ArJobSurveyHd",
                column: "JobTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobSurveyHd_FndLookupValues_VehicleColorLkpId",
                table: "ArJobSurveyHd",
                column: "VehicleColorLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobSurveyHd_FndLookupValues_VehicleEmirateLkpId",
                table: "ArJobSurveyHd",
                column: "VehicleEmirateLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArJobSurveyHd_ArCustomers_ArCustomerId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArJobSurveyHd_FndLookupValues_JobTypeLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArJobSurveyHd_FndLookupValues_VehicleColorLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropForeignKey(
                name: "FK_ArJobSurveyHd_FndLookupValues_VehicleEmirateLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropIndex(
                name: "IX_ArJobSurveyHd_ArCustomerId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropIndex(
                name: "IX_ArJobSurveyHd_JobTypeLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropIndex(
                name: "IX_ArJobSurveyHd_VehicleColorLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropIndex(
                name: "IX_ArJobSurveyHd_VehicleEmirateLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "ArCustomerId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "Attribute1",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "Attribute2",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "Attribute3",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "Attribute4",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "EstimatedAmount",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "JobTypeLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "LabourCharges",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "VehicleColorLkpId",
                table: "ArJobSurveyHd");

            migrationBuilder.DropColumn(
                name: "VehicleEmirateLkpId",
                table: "ArJobSurveyHd");
        }
    }
}
