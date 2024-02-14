using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class tenantCountryAndIndustry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ApMiscPaymentLines_PortalUserData_PortalUserDataId",
            //    table: "ApMiscPaymentLines");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ScCampainsDetail_PortalUserData_PortalUserDataId",
            //    table: "ScCampainsDetail");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
            //    table: "ScPortalRequests");

            //migrationBuilder.DropIndex(
            //    name: "IX_ScPortalRequests_PortalUserDataId",
            //    table: "ScPortalRequests");

            //migrationBuilder.DropIndex(
            //    name: "IX_ScCampainsDetail_PortalUserDataId",
            //    table: "ScCampainsDetail");

            //migrationBuilder.DropIndex(
            //    name: "IX_ApMiscPaymentLines_PortalUserDataId",
            //    table: "ApMiscPaymentLines");

            //migrationBuilder.DropColumn(
            //    name: "PortalUserDataId",
            //    table: "ScPortalRequests");

            //migrationBuilder.DropColumn(
            //    name: "PortalUserDataId",
            //    table: "ScCampainsDetail");

            //migrationBuilder.DropColumn(
            //    name: "PortalUserDataId",
            //    table: "ApMiscPaymentLines");

            migrationBuilder.AddColumn<long>(
                name: "CountryLkpId",
                table: "AbpTenants",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IndustryLkpId",
                table: "AbpTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryLkpId",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "IndustryLkpId",
                table: "AbpTenants");

            migrationBuilder.AddColumn<long>(
                name: "PortalUserDataId",
                table: "ScPortalRequests",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PortalUserDataId",
                table: "ScCampainsDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PortalUserDataId",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_PortalUserDataId",
                table: "ScPortalRequests",
                column: "PortalUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCampainsDetail_PortalUserDataId",
                table: "ScCampainsDetail",
                column: "PortalUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_PortalUserDataId",
                table: "ApMiscPaymentLines",
                column: "PortalUserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentLines_PortalUserData_PortalUserDataId",
                table: "ApMiscPaymentLines",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScCampainsDetail_PortalUserData_PortalUserDataId",
                table: "ScCampainsDetail",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
