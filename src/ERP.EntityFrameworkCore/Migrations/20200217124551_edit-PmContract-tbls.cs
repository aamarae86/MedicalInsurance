using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPmContracttbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmContractAttachments_PmContract_PmContractId",
                table: "PmContractAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractPayments_PmContract_PmContractId",
                table: "PmContractPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractUnitDetails_PmContract_PmContractId",
                table: "PmContractUnitDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOtherContractPayments_PmContract_PmContractId",
                table: "PmOtherContractPayments");

            migrationBuilder.DropColumn(
                name: "PmPaymentTypeLkpId",
                table: "PmContract");

            migrationBuilder.RenameColumn(
                name: "PaymentSourceLkpID",
                table: "PmContractPayments",
                newName: "PaymentSourceLkpId");

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmOtherContractPayments",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OtherPaymentTypesId",
                table: "PmOtherContractPayments",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PmOtherContractPayments",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PropertiesUnitId",
                table: "PmContractUnitDetails",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmContractUnitDetails",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PmContractUnitDetails",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmContractPayments",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentTypeLkpId",
                table: "PmContractPayments",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentSourceLkpId",
                table: "PmContractPayments",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "PmContractPayments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PmContractPayments",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmContractAttachments",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmContractAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AttachmentName",
                table: "PmContractAttachments",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxPercent",
                table: "PmContract",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxNo",
                table: "PmContract",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RentAmount",
                table: "PmContract",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PmUnitTypeLkpId",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PmTenantId",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PmActivityLkpId",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InsuranceAmount",
                table: "PmContract",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractStartDate",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDatePrint",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "PmContract",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PmPaymentNoLkpId",
                table: "PmContract",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PmOtherContractPayments_OtherPaymentTypesId",
                table: "PmOtherContractPayments",
                column: "OtherPaymentTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContractUnitDetails_PropertiesUnitId",
                table: "PmContractUnitDetails",
                column: "PropertiesUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContractPayments_BankLkpId",
                table: "PmContractPayments",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContractPayments_PaymentSourceLkpId",
                table: "PmContractPayments",
                column: "PaymentSourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContractPayments_PaymentTypeLkpId",
                table: "PmContractPayments",
                column: "PaymentTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_ParentContractId",
                table: "PmContract",
                column: "ParentContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_PmActivityLkpId",
                table: "PmContract",
                column: "PmActivityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_PmPaymentNoLkpId",
                table: "PmContract",
                column: "PmPaymentNoLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_PmTenantId",
                table: "PmContract",
                column: "PmTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_PmUnitTypeLkpId",
                table: "PmContract",
                column: "PmUnitTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_PropertyId",
                table: "PmContract",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContract_StatusLkpId",
                table: "PmContract",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_PmContract_ParentContractId",
                table: "PmContract",
                column: "ParentContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_FndLookupValues_PmActivityLkpId",
                table: "PmContract",
                column: "PmActivityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_FndLookupValues_PmPaymentNoLkpId",
                table: "PmContract",
                column: "PmPaymentNoLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_PmTenants_PmTenantId",
                table: "PmContract",
                column: "PmTenantId",
                principalTable: "PmTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_FndLookupValues_PmUnitTypeLkpId",
                table: "PmContract",
                column: "PmUnitTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_PmProperties_PropertyId",
                table: "PmContract",
                column: "PropertyId",
                principalTable: "PmProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContract_FndLookupValues_StatusLkpId",
                table: "PmContract",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractAttachments_PmContract_PmContractId",
                table: "PmContractAttachments",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_BankLkpId",
                table: "PmContractPayments",
                column: "BankLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_PaymentSourceLkpId",
                table: "PmContractPayments",
                column: "PaymentSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_PaymentTypeLkpId",
                table: "PmContractPayments",
                column: "PaymentTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractPayments_PmContract_PmContractId",
                table: "PmContractPayments",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractUnitDetails_PmContract_PmContractId",
                table: "PmContractUnitDetails",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractUnitDetails_PmPropertiesUnits_PropertiesUnitId",
                table: "PmContractUnitDetails",
                column: "PropertiesUnitId",
                principalTable: "PmPropertiesUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOtherContractPayments_PmOtherPaymentTypes_OtherPaymentTypesId",
                table: "PmOtherContractPayments",
                column: "OtherPaymentTypesId",
                principalTable: "PmOtherPaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOtherContractPayments_PmContract_PmContractId",
                table: "PmOtherContractPayments",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_PmContract_ParentContractId",
                table: "PmContract");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_FndLookupValues_PmActivityLkpId",
                table: "PmContract");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_FndLookupValues_PmPaymentNoLkpId",
                table: "PmContract");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_PmTenants_PmTenantId",
                table: "PmContract");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_FndLookupValues_PmUnitTypeLkpId",
                table: "PmContract");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_PmProperties_PropertyId",
                table: "PmContract");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContract_FndLookupValues_StatusLkpId",
                table: "PmContract");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractAttachments_PmContract_PmContractId",
                table: "PmContractAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_BankLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_PaymentSourceLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractPayments_FndLookupValues_PaymentTypeLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractPayments_PmContract_PmContractId",
                table: "PmContractPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractUnitDetails_PmContract_PmContractId",
                table: "PmContractUnitDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PmContractUnitDetails_PmPropertiesUnits_PropertiesUnitId",
                table: "PmContractUnitDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOtherContractPayments_PmOtherPaymentTypes_OtherPaymentTypesId",
                table: "PmOtherContractPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOtherContractPayments_PmContract_PmContractId",
                table: "PmOtherContractPayments");

            migrationBuilder.DropIndex(
                name: "IX_PmOtherContractPayments_OtherPaymentTypesId",
                table: "PmOtherContractPayments");

            migrationBuilder.DropIndex(
                name: "IX_PmContractUnitDetails_PropertiesUnitId",
                table: "PmContractUnitDetails");

            migrationBuilder.DropIndex(
                name: "IX_PmContractPayments_BankLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropIndex(
                name: "IX_PmContractPayments_PaymentSourceLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropIndex(
                name: "IX_PmContractPayments_PaymentTypeLkpId",
                table: "PmContractPayments");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_ParentContractId",
                table: "PmContract");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_PmActivityLkpId",
                table: "PmContract");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_PmPaymentNoLkpId",
                table: "PmContract");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_PmTenantId",
                table: "PmContract");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_PmUnitTypeLkpId",
                table: "PmContract");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_PropertyId",
                table: "PmContract");

            migrationBuilder.DropIndex(
                name: "IX_PmContract_StatusLkpId",
                table: "PmContract");

            migrationBuilder.DropColumn(
                name: "PmPaymentNoLkpId",
                table: "PmContract");

            migrationBuilder.RenameColumn(
                name: "PaymentSourceLkpId",
                table: "PmContractPayments",
                newName: "PaymentSourceLkpID");

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmOtherContractPayments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "OtherPaymentTypesId",
                table: "PmOtherContractPayments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PmOtherContractPayments",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<long>(
                name: "PropertiesUnitId",
                table: "PmContractUnitDetails",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmContractUnitDetails",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PmContractUnitDetails",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmContractPayments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PaymentTypeLkpId",
                table: "PmContractPayments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PaymentSourceLkpID",
                table: "PmContractPayments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "PmContractPayments",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PmContractPayments",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<long>(
                name: "PmContractId",
                table: "PmContractAttachments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmContractAttachments",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "AttachmentName",
                table: "PmContractAttachments",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxPercent",
                table: "PmContract",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<string>(
                name: "TaxNo",
                table: "PmContract",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "RentAmount",
                table: "PmContract",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PmUnitTypeLkpId",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PmTenantId",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PmActivityLkpId",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "InsuranceAmount",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractStartDate",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDatePrint",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "PmContract",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<long>(
                name: "PmPaymentTypeLkpId",
                table: "PmContract",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractAttachments_PmContract_PmContractId",
                table: "PmContractAttachments",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractPayments_PmContract_PmContractId",
                table: "PmContractPayments",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmContractUnitDetails_PmContract_PmContractId",
                table: "PmContractUnitDetails",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOtherContractPayments_PmContract_PmContractId",
                table: "PmOtherContractPayments",
                column: "PmContractId",
                principalTable: "PmContract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
