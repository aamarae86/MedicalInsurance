using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class removeColumnNotNeededPUAQ156 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_FndLookupValuesId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_ScCommittees_FndLookupValues_FndLookupValuesId",
                table: "ScCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ScCommittees_ScPortalRequestStudy_ScPortalRequestStudyId",
                table: "ScCommittees");

            migrationBuilder.DropIndex(
                name: "IX_ScCommittees_FndLookupValuesId",
                table: "ScCommittees");

            migrationBuilder.DropIndex(
                name: "IX_ScCommittees_ScPortalRequestStudyId",
                table: "ScCommittees");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentHeaders_FndLookupValuesId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "FndLookupValuesId",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "ScPortalRequestStudyId",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "FndLookupValuesId",
                table: "ApMiscPaymentHeaders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndLookupValuesId",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScPortalRequestStudyId",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FndLookupValuesId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScCommittees_FndLookupValuesId",
                table: "ScCommittees",
                column: "FndLookupValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommittees_ScPortalRequestStudyId",
                table: "ScCommittees",
                column: "ScPortalRequestStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentHeaders_FndLookupValuesId",
                table: "ApMiscPaymentHeaders",
                column: "FndLookupValuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_FndLookupValuesId",
                table: "ApMiscPaymentHeaders",
                column: "FndLookupValuesId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommittees_FndLookupValues_FndLookupValuesId",
                table: "ScCommittees",
                column: "FndLookupValuesId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommittees_ScPortalRequestStudy_ScPortalRequestStudyId",
                table: "ScCommittees",
                column: "ScPortalRequestStudyId",
                principalTable: "ScPortalRequestStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
