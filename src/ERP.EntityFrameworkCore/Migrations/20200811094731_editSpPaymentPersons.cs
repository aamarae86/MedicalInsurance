using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editSpPaymentPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpPaymentPersons_SpCasesPaymentDeserving_SpCasesPaymentDeservingId",
                table: "SpPaymentPersons");

            migrationBuilder.DropIndex(
                name: "IX_SpPaymentPersons_SpCasesPaymentDeservingId",
                table: "SpPaymentPersons");

            migrationBuilder.DropColumn(
                name: "SpCasesPaymentDeservingId",
                table: "SpPaymentPersons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SpCasesPaymentDeservingId",
                table: "SpPaymentPersons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpPaymentPersons_SpCasesPaymentDeservingId",
                table: "SpPaymentPersons",
                column: "SpCasesPaymentDeservingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpPaymentPersons_SpCasesPaymentDeserving_SpCasesPaymentDeservingId",
                table: "SpPaymentPersons",
                column: "SpCasesPaymentDeservingId",
                principalTable: "SpCasesPaymentDeserving",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
