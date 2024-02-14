using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PortalUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserAttachments_PortalUsers_PortalUserId",
                table: "PortalUserAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserDuties_PortalUsers_PortalUserId",
                table: "PortalUserDuties");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserIncomes_PortalUsers_PortalUserId",
                table: "PortalUserIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_PortalUsers_PortalUserId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUsersId",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "IsZakat",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "UserTenants",
                table: "PortalUsers");

            migrationBuilder.RenameColumn(
                name: "PortalUsersId",
                table: "ScPortalRequests",
                newName: "PortalUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_ScPortalRequests_PortalUsersId",
                table: "ScPortalRequests",
                newName: "IX_ScPortalRequests_PortalUserDataId");

            migrationBuilder.RenameColumn(
                name: "PortalUserId",
                table: "PortalUserRelatives",
                newName: "PortalUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserRelatives_PortalUserId",
                table: "PortalUserRelatives",
                newName: "IX_PortalUserRelatives_PortalUserDataId");

            migrationBuilder.RenameColumn(
                name: "PortalUserId",
                table: "PortalUserIncomes",
                newName: "PortalUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserIncomes_PortalUserId",
                table: "PortalUserIncomes",
                newName: "IX_PortalUserIncomes_PortalUserDataId");

            migrationBuilder.RenameColumn(
                name: "PortalUserId",
                table: "PortalUserDuties",
                newName: "PortalUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserDuties_PortalUserId",
                table: "PortalUserDuties",
                newName: "IX_PortalUserDuties_PortalUserDataId");

            migrationBuilder.RenameColumn(
                name: "PortalUserId",
                table: "PortalUserAttachments",
                newName: "PortalUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserAttachments_PortalUserId",
                table: "PortalUserAttachments",
                newName: "IX_PortalUserAttachments_PortalUserDataId");

            migrationBuilder.AddColumn<long>(
                name: "PortalUserDataId",
                table: "ScCampainsDetail",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PortalUsers",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PortalUserDataId",
                table: "ApMiscPaymentLines",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PortalUserData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Region = table.Column<string>(maxLength: 200, nullable: false),
                    MobileNumber1 = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNumber2 = table.Column<string>(maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    IdExpirationDate = table.Column<DateTime>(nullable: false),
                    PassportExpiryDate = table.Column<DateTime>(nullable: true),
                    PassportIssueDate = table.Column<DateTime>(nullable: true),
                    ResidenceEndDate = table.Column<DateTime>(nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 100, nullable: true),
                    UnifiedNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Job = table.Column<string>(maxLength: 200, nullable: true),
                    JobDescription = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 4000, nullable: true),
                    MaritalStatusLkpId = table.Column<long>(nullable: false),
                    GenderLkpId = table.Column<long>(nullable: false),
                    CityLkpId = table.Column<long>(nullable: false),
                    CaseCategoryLkpId = table.Column<long>(nullable: true),
                    QualificationLkpId = table.Column<long>(nullable: true),
                    PortalUserId = table.Column<long>(nullable: false),
                    IsZakat = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalUserData_FndLookupValues_CaseCategoryLkpId",
                        column: x => x.CaseCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PortalUserData_FndLookupValues_CityLkpId",
                        column: x => x.CityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortalUserData_FndLookupValues_GenderLkpId",
                        column: x => x.GenderLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortalUserData_FndLookupValues_MaritalStatusLkpId",
                        column: x => x.MaritalStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PortalUserData_PortalUsers_PortalUserId",
                        column: x => x.PortalUserId,
                        principalTable: "PortalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortalUserData_FndLookupValues_QualificationLkpId",
                        column: x => x.QualificationLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScCampainsDetail_PortalUserDataId",
                table: "ScCampainsDetail",
                column: "PortalUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ApMiscPaymentLines_PortalUserDataId",
                table: "ApMiscPaymentLines",
                column: "PortalUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserData_CaseCategoryLkpId",
                table: "PortalUserData",
                column: "CaseCategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserData_CityLkpId",
                table: "PortalUserData",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserData_GenderLkpId",
                table: "PortalUserData",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserData_MaritalStatusLkpId",
                table: "PortalUserData",
                column: "MaritalStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserData_PortalUserId",
                table: "PortalUserData",
                column: "PortalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserData_QualificationLkpId",
                table: "PortalUserData",
                column: "QualificationLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApMiscPaymentLines_PortalUserData_PortalUserDataId",
                table: "ApMiscPaymentLines",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserAttachments_PortalUserData_PortalUserDataId",
                table: "PortalUserAttachments",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserDuties_PortalUserData_PortalUserDataId",
                table: "PortalUserDuties",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserIncomes_PortalUserData_PortalUserDataId",
                table: "PortalUserIncomes",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_PortalUserData_PortalUserDataId",
                table: "PortalUserRelatives",
                column: "PortalUserDataId",
                principalTable: "PortalUserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApMiscPaymentLines_PortalUserData_PortalUserDataId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserAttachments_PortalUserData_PortalUserDataId",
                table: "PortalUserAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserDuties_PortalUserData_PortalUserDataId",
                table: "PortalUserDuties");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserIncomes_PortalUserData_PortalUserDataId",
                table: "PortalUserIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_PortalUserData_PortalUserDataId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_ScCampainsDetail_PortalUserData_PortalUserDataId",
                table: "ScCampainsDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_PortalUserData_PortalUserDataId",
                table: "ScPortalRequests");

            migrationBuilder.DropTable(
                name: "PortalUserData");

            migrationBuilder.DropIndex(
                name: "IX_ScCampainsDetail_PortalUserDataId",
                table: "ScCampainsDetail");

            migrationBuilder.DropIndex(
                name: "IX_ApMiscPaymentLines_PortalUserDataId",
                table: "ApMiscPaymentLines");

            migrationBuilder.DropColumn(
                name: "PortalUserDataId",
                table: "ScCampainsDetail");

            migrationBuilder.DropColumn(
                name: "PortalUserDataId",
                table: "ApMiscPaymentLines");

            migrationBuilder.RenameColumn(
                name: "PortalUserDataId",
                table: "ScPortalRequests",
                newName: "PortalUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_ScPortalRequests_PortalUserDataId",
                table: "ScPortalRequests",
                newName: "IX_ScPortalRequests_PortalUsersId");

            migrationBuilder.RenameColumn(
                name: "PortalUserDataId",
                table: "PortalUserRelatives",
                newName: "PortalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserRelatives_PortalUserDataId",
                table: "PortalUserRelatives",
                newName: "IX_PortalUserRelatives_PortalUserId");

            migrationBuilder.RenameColumn(
                name: "PortalUserDataId",
                table: "PortalUserIncomes",
                newName: "PortalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserIncomes_PortalUserDataId",
                table: "PortalUserIncomes",
                newName: "IX_PortalUserIncomes_PortalUserId");

            migrationBuilder.RenameColumn(
                name: "PortalUserDataId",
                table: "PortalUserDuties",
                newName: "PortalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserDuties_PortalUserDataId",
                table: "PortalUserDuties",
                newName: "IX_PortalUserDuties_PortalUserId");

            migrationBuilder.RenameColumn(
                name: "PortalUserDataId",
                table: "PortalUserAttachments",
                newName: "PortalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PortalUserAttachments_PortalUserDataId",
                table: "PortalUserAttachments",
                newName: "IX_PortalUserAttachments_PortalUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PortalUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddColumn<long>(
                name: "IsZakat",
                table: "PortalUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserTenants",
                table: "PortalUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserAttachments_PortalUsers_PortalUserId",
                table: "PortalUserAttachments",
                column: "PortalUserId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserDuties_PortalUsers_PortalUserId",
                table: "PortalUserDuties",
                column: "PortalUserId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserIncomes_PortalUsers_PortalUserId",
                table: "PortalUserIncomes",
                column: "PortalUserId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_PortalUsers_PortalUserId",
                table: "PortalUserRelatives",
                column: "PortalUserId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_PortalUsers_PortalUsersId",
                table: "ScPortalRequests",
                column: "PortalUsersId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
