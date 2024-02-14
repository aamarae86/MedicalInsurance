using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class miscpaymentedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ApMiscPaymentDetails");

            migrationBuilder.AddColumn<long>(
                name: "FndLookupValuesId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentTypeLkpId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceCodeLkpId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentHeaders_FndLookupValuesId",
                table: "ApMiscPaymentHeaders",
                column: "FndLookupValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentHeaders_PaymentTypeLkpId",
                table: "ApMiscPaymentHeaders",
                column: "PaymentTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentHeaders_SourceCodeLkpId",
                table: "ApMiscPaymentHeaders",
                column: "SourceCodeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_FndLookupValuesId",
                table: "ApMiscPaymentHeaders",
                column: "FndLookupValuesId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_PaymentTypeLkpId",
                table: "ApMiscPaymentHeaders",
                column: "PaymentTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_SourceCodeLkpId",
                table: "ApMiscPaymentHeaders",
                column: "SourceCodeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_FndLookupValuesId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_PaymentTypeLkpId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentHeaders_FndLookupValues_SourceCodeLkpId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentHeaders_FndLookupValuesId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentHeaders_PaymentTypeLkpId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentHeaders_SourceCodeLkpId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "FndLookupValuesId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "PaymentTypeLkpId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "SourceCodeLkpId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ApMiscPaymentLines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ApMiscPaymentHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ApMiscPaymentDetails",
                nullable: false,
                defaultValue: false);
        }
    }
}
