using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPyPayrollOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PyPayrollOperations_HrPersons_HrPersonId",
                table: "PyPayrollOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_PyPayrollOperations_FndLookupValues_JobLkpId",
                table: "PyPayrollOperations");

            migrationBuilder.AlterColumn<long>(
                name: "JobLkpId",
                table: "PyPayrollOperations",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "HrPersonId",
                table: "PyPayrollOperations",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "EarningAmount",
                table: "PyPayrollOperationPersonDetails",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "deciaml(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeductionAmount",
                table: "PyPayrollOperationPersonDetails",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "deciaml(18,6)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PyPayrollOperationPersonDetails_PyPayrollOperationPersonId",
                table: "PyPayrollOperationPersonDetails",
                column: "PyPayrollOperationPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PyPayrollOperationPersonDetails_PyPayrollOperationPersons_PyPayrollOperationPersonId",
                table: "PyPayrollOperationPersonDetails",
                column: "PyPayrollOperationPersonId",
                principalTable: "PyPayrollOperationPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PyPayrollOperations_HrPersons_HrPersonId",
                table: "PyPayrollOperations",
                column: "HrPersonId",
                principalTable: "HrPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PyPayrollOperations_FndLookupValues_JobLkpId",
                table: "PyPayrollOperations",
                column: "JobLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PyPayrollOperationPersonDetails_PyPayrollOperationPersons_PyPayrollOperationPersonId",
                table: "PyPayrollOperationPersonDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PyPayrollOperations_HrPersons_HrPersonId",
                table: "PyPayrollOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_PyPayrollOperations_FndLookupValues_JobLkpId",
                table: "PyPayrollOperations");

            migrationBuilder.DropIndex(
                name: "IX_PyPayrollOperationPersonDetails_PyPayrollOperationPersonId",
                table: "PyPayrollOperationPersonDetails");

            migrationBuilder.AlterColumn<long>(
                name: "JobLkpId",
                table: "PyPayrollOperations",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HrPersonId",
                table: "PyPayrollOperations",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EarningAmount",
                table: "PyPayrollOperationPersonDetails",
                type: "deciaml(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeductionAmount",
                table: "PyPayrollOperationPersonDetails",
                type: "deciaml(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PyPayrollOperations_HrPersons_HrPersonId",
                table: "PyPayrollOperations",
                column: "HrPersonId",
                principalTable: "HrPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PyPayrollOperations_FndLookupValues_JobLkpId",
                table: "PyPayrollOperations",
                column: "JobLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
