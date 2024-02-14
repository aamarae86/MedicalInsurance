using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PmTenantsValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTenantsAttachments_PmTenants_PmTenantId",
                table: "PmTenantsAttachments");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "PmTenants",
                newName: "Region");

            migrationBuilder.AlterColumn<long>(
                name: "PmTenantId",
                table: "PmTenantsAttachments",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmTenantsAttachments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AttachmentName",
                table: "PmTenantsAttachments",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenantNumber",
                table: "PmTenants",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenantNameEn",
                table: "PmTenants",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenantNameAr",
                table: "PmTenants",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "PmTenants",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommercialLicenseExpiryDate",
                table: "PmTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommercialLicenseNumber",
                table: "PmTenants",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResidenceEndDate",
                table: "PmTenants",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners",
                column: "BankAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners",
                column: "CashAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners",
                column: "CurrentAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenantsAttachments_PmTenants_PmTenantId",
                table: "PmTenantsAttachments",
                column: "PmTenantId",
                principalTable: "PmTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PmTenantsAttachments_PmTenants_PmTenantId",
                table: "PmTenantsAttachments");

            migrationBuilder.DropColumn(
                name: "CommercialLicenseExpiryDate",
                table: "PmTenants");

            migrationBuilder.DropColumn(
                name: "CommercialLicenseNumber",
                table: "PmTenants");

            migrationBuilder.DropColumn(
                name: "ResidenceEndDate",
                table: "PmTenants");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "PmTenants",
                newName: "Notes");

            migrationBuilder.AlterColumn<long>(
                name: "PmTenantId",
                table: "PmTenantsAttachments",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "PmTenantsAttachments",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "AttachmentName",
                table: "PmTenantsAttachments",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TenantNumber",
                table: "PmTenants",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "TenantNameEn",
                table: "PmTenants",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TenantNameAr",
                table: "PmTenants",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "PmTenants",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_AccountId",
                table: "PmOwners",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_BankAccountId",
                table: "PmOwners",
                column: "BankAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CashAccountId",
                table: "PmOwners",
                column: "CashAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmOwners_GlCodeComDetails_CurrentAccountId",
                table: "PmOwners",
                column: "CurrentAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenantsAttachments_PmTenants_PmTenantId",
                table: "PmTenantsAttachments",
                column: "PmTenantId",
                principalTable: "PmTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
