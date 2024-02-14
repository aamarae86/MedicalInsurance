using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ModifyArInvoiceHdConstraints : Migration
    { 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
             name: "FK_ArInvoiceTr_ArInvoiceHd_ArInvoiceHdId",
             table: "ArInvoiceTr");

            migrationBuilder.AddForeignKey(
                      name: "FK_ArInvoiceTr_ArInvoiceHd_ArInvoiceHdId",
                      table: "ArInvoiceTr",
                      column: "ArInvoiceHdId",
                      principalTable: "ArInvoiceHd",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
              name: "FK_ArInvoiceTr_ArInvoiceHd_ArInvoiceHdId",
              table: "ArInvoiceTr");
        }
    }
}
