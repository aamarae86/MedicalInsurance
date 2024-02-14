using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPyPayrollOperationPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PyPayrollOperationPersons_FndLookupValues_BankLkpId",
                table: "PyPayrollOperationPersons");

            migrationBuilder.AlterColumn<long>(
                name: "BankLkpId",
                table: "PyPayrollOperationPersons",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PyPayrollOperationPersons_FndLookupValues_BankLkpId",
                table: "PyPayrollOperationPersons",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PyPayrollOperationPersons_FndLookupValues_BankLkpId",
                table: "PyPayrollOperationPersons");

            migrationBuilder.AlterColumn<long>(
                name: "BankLkpId",
                table: "PyPayrollOperationPersons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PyPayrollOperationPersons_FndLookupValues_BankLkpId",
                table: "PyPayrollOperationPersons",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
