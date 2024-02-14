using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_PaymentTermsLkp_ArCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PaymentTermsLkpId",
                table: "ArCustomers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArCustomers_PaymentTermsLkpId",
                table: "ArCustomers",
                column: "PaymentTermsLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArCustomers_FndLookupValues_PaymentTermsLkpId",
                table: "ArCustomers",
                column: "PaymentTermsLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArCustomers_FndLookupValues_PaymentTermsLkpId",
                table: "ArCustomers");

            migrationBuilder.DropIndex(
                name: "IX_ArCustomers_PaymentTermsLkpId",
                table: "ArCustomers");

            migrationBuilder.DropColumn(
                name: "PaymentTermsLkpId",
                table: "ArCustomers");
        }
    }
}
