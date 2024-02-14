using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addCrmLeadsPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrmLeadsPersons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PostUserId = table.Column<long>(nullable: true),
                    PostTime = table.Column<DateTime>(nullable: true),
                    UnPostUserId = table.Column<long>(nullable: true),
                    UnPostTime = table.Column<DateTime>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    LeadStatusIdLkp = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    Phone = table.Column<string>(maxLength: 30, nullable: true),
                    Fax = table.Column<string>(maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    SecondaryEmail = table.Column<string>(maxLength: 150, nullable: true),
                    Company = table.Column<string>(maxLength: 500, nullable: true),
                    Website = table.Column<string>(maxLength: 500, nullable: true),
                    LeadSourceLkpId = table.Column<long>(nullable: false),
                    IndustryLkpId = table.Column<long>(nullable: false),
                    AnnualRevenue = table.Column<decimal>(nullable: false),
                    NoOfEmployees = table.Column<int>(nullable: false),
                    RatingLkpId = table.Column<long>(nullable: false),
                    Skype = table.Column<string>(maxLength: 30, nullable: true),
                    Twitter = table.Column<string>(maxLength: 200, nullable: true),
                    EmailOptOutId = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Street = table.Column<string>(maxLength: 2000, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    State = table.Column<string>(maxLength: 30, nullable: true),
                    CountryLkpId = table.Column<long>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 30, nullable: true),
                    LeadImage = table.Column<string>(maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmLeadsPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrmLeadsPersons_FndLookupValues_CountryLkpId",
                        column: x => x.CountryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrmLeadsPersons_FndLookupValues_IndustryLkpId",
                        column: x => x.IndustryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrmLeadsPersons_FndLookupValues_LeadSourceLkpId",
                        column: x => x.LeadSourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrmLeadsPersons_FndLookupValues_LeadStatusIdLkp",
                        column: x => x.LeadStatusIdLkp,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CrmLeadsPersons_FndLookupValues_RatingLkpId",
                        column: x => x.RatingLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_CountryLkpId",
                table: "CrmLeadsPersons",
                column: "CountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_IndustryLkpId",
                table: "CrmLeadsPersons",
                column: "IndustryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_LeadSourceLkpId",
                table: "CrmLeadsPersons",
                column: "LeadSourceLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_LeadStatusIdLkp",
                table: "CrmLeadsPersons",
                column: "LeadStatusIdLkp");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_RatingLkpId",
                table: "CrmLeadsPersons",
                column: "RatingLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrmLeadsPersons");
        }
    }
}
