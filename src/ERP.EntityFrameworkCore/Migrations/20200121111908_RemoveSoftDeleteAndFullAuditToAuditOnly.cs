using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class RemoveSoftDeleteAndFullAuditToAuditOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ScFndAidRequestType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ScFndAidRequestType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ScFndAidRequestType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlPeriodsYears");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlPeriodsYears");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlPeriodsYears");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlPeriodsDetails");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlPeriodsDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlPeriodsDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlMainAccounts");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlMainAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlMainAccounts");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlJeLines");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlJeHeaders");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlCodeComDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlAccounts");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlAccounts");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlAccHeaders");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlAccHeaders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlAccHeaders");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "GlAccDetails");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "GlAccDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GlAccDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "FndLookupValues");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "FndLookupValues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FndLookupValues");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "FndCollectors");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "FndCollectors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FndCollectors");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "CountersDetails");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "CountersDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CountersDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Counters");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArMiscReceiptLines");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ArMiscReceiptDetails");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ArMiscReceiptDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArMiscReceiptDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ArCustomers");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ArCustomers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArCustomers");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApVendors");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApVendors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApVendors");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApUserBankAccess");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApUserBankAccess");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApUserBankAccess");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApMiscPaymentDetails");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApMiscPaymentDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApMiscPaymentDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApBanks");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApBanks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApBanks");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ApBankAccounts");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ApBankAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApBankAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SpBeneficent",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ScFndAidRequestType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ScFndAidRequestType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ScFndAidRequestType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlPeriodsYears",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlPeriodsYears",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlPeriodsYears",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlPeriodsDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlPeriodsDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlPeriodsDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlMainAccounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlMainAccounts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlMainAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlJeLines",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlJeLines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlJeHeaders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlJeHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlCodeComDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlCodeComDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlAccounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlAccounts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlAccHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlAccHeaders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlAccHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "GlAccDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "GlAccDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GlAccDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "FndLookupValues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "FndLookupValues",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FndLookupValues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "FndCollectors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "FndCollectors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FndCollectors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Currencies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Currencies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Currencies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "CountersDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "CountersDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CountersDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Counters",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Counters",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Counters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArPdcInterface",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ArMiscReceiptLines",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ArMiscReceiptLines",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArMiscReceiptLines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArMiscReceiptHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ArMiscReceiptDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ArMiscReceiptDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArMiscReceiptDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ArCustomers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ArCustomers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArCustomers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApVendors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApVendors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApVendors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApUserBankAccess",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApUserBankAccess",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApUserBankAccess",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApPdcInterface",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApMiscPaymentLines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApMiscPaymentHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApMiscPaymentDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApMiscPaymentDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApMiscPaymentDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApBanks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApBanks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApBanks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ApBankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ApBankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApBankAccounts",
                nullable: false,
                defaultValue: false);
        }
    }
}
