using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ScProtalRequest_and_ScFndProtalAttachmentSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScPortalRequests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    PortalUsersId = table.Column<long>(nullable: false),
                    PortalRequestDate = table.Column<DateTime>(nullable: false),
                    PortalRequestNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AidRequestTypeId = table.Column<long>(nullable: false),
                    HealthstatusLkpId = table.Column<long>(nullable: false),
                    IncomeSource = table.Column<string>(maxLength: 4000, nullable: true),
                    MonthlyIncomeAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    MonthlyOutcomeAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    SourceLkpId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: false),
                    IdExpirationDate = table.Column<DateTime>(nullable: false),
                    WifeHusbandName1 = table.Column<string>(maxLength: 200, nullable: true),
                    IdNumberWifeHusband1 = table.Column<string>(maxLength: 50, nullable: true),
                    WifeName2 = table.Column<string>(maxLength: 200, nullable: true),
                    IdNumberWife2 = table.Column<string>(maxLength: 50, nullable: true),
                    WifeName3 = table.Column<string>(maxLength: 200, nullable: true),
                    IdNumberWife3 = table.Column<string>(maxLength: 50, nullable: true),
                    WifeName4 = table.Column<string>(maxLength: 200, nullable: true),
                    IdNumberWife4 = table.Column<string>(maxLength: 50, nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    MobileNumber1 = table.Column<string>(maxLength: 50, nullable: true),
                    MobileNumber2 = table.Column<string>(maxLength: 50, nullable: true),
                    JobDescription = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 4000, nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    Qualification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScPortalRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScPortalRequests_ScFndAidRequestType_AidRequestTypeId",
                        column: x => x.AidRequestTypeId,
                        principalTable: "ScFndAidRequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScPortalRequests_FndLookupValues_HealthstatusLkpId",
                        column: x => x.HealthstatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScPortalRequests_PortalUsers_PortalUsersId",
                        column: x => x.PortalUsersId,
                        principalTable: "PortalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScPortalRequests_FndLookupValues_SourceLkpId",
                        column: x => x.SourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ScPortalRequests_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PortalRequestAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    PortalRequestId = table.Column<long>(nullable: false),
                    FilePath = table.Column<string>(maxLength: 500, nullable: true),
                    ProtalAttachmentSettingId = table.Column<long>(nullable: false),
                    ScPortalRequestId = table.Column<long>(nullable: true),
                    GetScFndProtalAttachmentSettingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalRequestAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalRequestAttachments_ScFndProtalAttachmentSetting_GetScFndProtalAttachmentSettingId",
                        column: x => x.GetScFndProtalAttachmentSettingId,
                        principalTable: "ScFndProtalAttachmentSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PortalRequestAttachments_ScPortalRequests_ScPortalRequestId",
                        column: x => x.ScPortalRequestId,
                        principalTable: "ScPortalRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortalRequestAttachments_GetScFndProtalAttachmentSettingId",
                table: "PortalRequestAttachments",
                column: "GetScFndProtalAttachmentSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalRequestAttachments_ScPortalRequestId",
                table: "PortalRequestAttachments",
                column: "ScPortalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_AidRequestTypeId",
                table: "ScPortalRequests",
                column: "AidRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_HealthstatusLkpId",
                table: "ScPortalRequests",
                column: "HealthstatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_PortalUsersId",
                table: "ScPortalRequests",
                column: "PortalUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_SourceLkpId",
                table: "ScPortalRequests",
                column: "SourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_StatusLkpId",
                table: "ScPortalRequests",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortalRequestAttachments");

            migrationBuilder.DropTable(
                name: "ScPortalRequests");
        }
    }
}
