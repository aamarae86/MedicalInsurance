using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PmTenantsAndItsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PmTenants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantNumber = table.Column<string>(maxLength: 30, nullable: true),
                    TenantNameAr = table.Column<string>(maxLength: 200, nullable: true),
                    TenantNameEn = table.Column<string>(maxLength: 200, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    IdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    NationalityLkpId = table.Column<long>(nullable: true),
                    CountryLkpId = table.Column<long>(nullable: true),
                    CityLkpId = table.Column<long>(nullable: true),
                    Address = table.Column<string>(maxLength: 4000, nullable: true),
                    HomePhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 32, nullable: true),
                    WorkPhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    Fax = table.Column<string>(maxLength: 32, nullable: true),
                    Website = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    JobName = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: true),
                    PoBox = table.Column<string>(maxLength: 100, nullable: true),
                    OtherAddress = table.Column<string>(maxLength: 4000, nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 100, nullable: true),
                    PassportIssueDate = table.Column<DateTime>(nullable: true),
                    PassportExpiryDate = table.Column<DateTime>(nullable: true),
                    PassportCountryLkpId = table.Column<long>(nullable: true),
                    SpecialGenderLkpId = table.Column<long>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    MaritalStatusLkpId = table.Column<long>(nullable: true),
                    PaymentMethodLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmTenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PmTenantsAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: true),
                    PmTenantId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmTenantsAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmTenantsAttachments_PmTenants_PmTenantId",
                        column: x => x.PmTenantId,
                        principalTable: "PmTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmTenantsAttachments_PmTenantId",
                table: "PmTenantsAttachments",
                column: "PmTenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmTenantsAttachments");

            migrationBuilder.DropTable(
                name: "PmTenants");
        }
    }
}
