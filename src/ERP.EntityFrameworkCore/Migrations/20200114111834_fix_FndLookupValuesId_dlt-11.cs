using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fix_FndLookupValuesId_dlt11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FndLookupValuesId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_FndLookupValuesId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentHeaders_FndLookupValuesId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "FndLookupValuesId",
                table: "ApMiscPaymentHeaders");
        }
    }
}
