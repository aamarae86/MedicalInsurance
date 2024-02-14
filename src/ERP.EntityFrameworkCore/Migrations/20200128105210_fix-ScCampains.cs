using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixScCampains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCampainsDetail_FndUsers_FndUsersId",
                table: "ScCampainsDetail");

            migrationBuilder.DropTable(
                name: "FndUserRelatives");

            migrationBuilder.DropTable(
                name: "FndUsers");

            migrationBuilder.DropColumn(
                name: "TrTax",
                table: "ApMiscPaymentLines");

            migrationBuilder.RenameColumn(
                name: "FndUsersId",
                table: "ScCampainsDetail",
                newName: "PortalFndUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_ScCampainsDetail_FndUsersId",
                table: "ScCampainsDetail",
                newName: "IX_ScCampainsDetail_PortalFndUsersId");

            migrationBuilder.AddColumn<string>(
                name: "CampainNumber",
                table: "ScCampains",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCampainsDetail_PortalUsers_PortalFndUsersId",
                table: "ScCampainsDetail",
                column: "PortalFndUsersId",
                principalTable: "PortalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCampainsDetail_PortalUsers_PortalFndUsersId",
                table: "ScCampainsDetail");

            migrationBuilder.DropColumn(
                name: "CampainNumber",
                table: "ScCampains");

            migrationBuilder.RenameColumn(
                name: "PortalFndUsersId",
                table: "ScCampainsDetail",
                newName: "FndUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_ScCampainsDetail_PortalFndUsersId",
                table: "ScCampainsDetail",
                newName: "IX_ScCampainsDetail_FndUsersId");

            migrationBuilder.AddColumn<decimal>(
                name: "TrTax",
                table: "ApMiscPaymentLines",
                type: "decimal(18, 6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FndUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 4000, nullable: true),
                    BrithDate = table.Column<DateTime>(nullable: false),
                    CityLkpId = table.Column<long>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    GenderLkpId = table.Column<long>(nullable: false),
                    IdExpirationDate = table.Column<DateTime>(nullable: false),
                    IdNumber = table.Column<string>(maxLength: 15, nullable: false),
                    IdNumberWife2 = table.Column<string>(maxLength: 15, nullable: true),
                    IdNumberWife3 = table.Column<string>(maxLength: 15, nullable: true),
                    IdNumberWife4 = table.Column<string>(maxLength: 15, nullable: true),
                    IdNumberWifeHusband1 = table.Column<string>(maxLength: 15, nullable: true),
                    JobDescription = table.Column<string>(maxLength: 200, nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MaritalStatusLkpId = table.Column<long>(nullable: false),
                    MobileNumber1 = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNumber2 = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    NationalityLkpId = table.Column<long>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PortalUsersId = table.Column<long>(nullable: true),
                    QualificationLkpId = table.Column<long>(nullable: true),
                    Region = table.Column<string>(maxLength: 200, nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    WifeHusbandName1 = table.Column<string>(maxLength: 200, nullable: true),
                    WifeName2 = table.Column<string>(maxLength: 200, nullable: true),
                    WifeName3 = table.Column<string>(maxLength: 200, nullable: true),
                    WifeName4 = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FndUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FndUsers_FndLookupValues_CityLkpId",
                        column: x => x.CityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FndUsers_FndLookupValues_GenderLkpId",
                        column: x => x.GenderLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FndUsers_FndLookupValues_MaritalStatusLkpId",
                        column: x => x.MaritalStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FndUsers_FndLookupValues_NationalityLkpId",
                        column: x => x.NationalityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FndUsers_FndLookupValues_QualificationLkpId",
                        column: x => x.QualificationLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FndUserRelatives",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    FndUsersId = table.Column<long>(nullable: false),
                    GenderLkpId = table.Column<long>(nullable: false),
                    IdNumber = table.Column<string>(maxLength: 15, nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    NationalityLkpId = table.Column<long>(nullable: true),
                    QualificationLkpId = table.Column<long>(nullable: true),
                    RelativesTypeLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FndUserRelatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FndUserRelatives_FndUsers_FndUsersId",
                        column: x => x.FndUsersId,
                        principalTable: "FndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FndUserRelatives_FndLookupValues_GenderLkpId",
                        column: x => x.GenderLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FndUserRelatives_FndLookupValues_NationalityLkpId",
                        column: x => x.NationalityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FndUserRelatives_FndLookupValues_QualificationLkpId",
                        column: x => x.QualificationLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FndUserRelatives_FndLookupValues_RelativesTypeLkpId",
                        column: x => x.RelativesTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FndUserRelatives_FndUsersId",
                table: "FndUserRelatives",
                column: "FndUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUserRelatives_GenderLkpId",
                table: "FndUserRelatives",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUserRelatives_NationalityLkpId",
                table: "FndUserRelatives",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUserRelatives_QualificationLkpId",
                table: "FndUserRelatives",
                column: "QualificationLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUserRelatives_RelativesTypeLkpId",
                table: "FndUserRelatives",
                column: "RelativesTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUsers_CityLkpId",
                table: "FndUsers",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUsers_GenderLkpId",
                table: "FndUsers",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUsers_MaritalStatusLkpId",
                table: "FndUsers",
                column: "MaritalStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUsers_NationalityLkpId",
                table: "FndUsers",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FndUsers_QualificationLkpId",
                table: "FndUsers",
                column: "QualificationLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCampainsDetail_FndUsers_FndUsersId",
                table: "ScCampainsDetail",
                column: "FndUsersId",
                principalTable: "FndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
