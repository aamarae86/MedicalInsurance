using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PortalUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPortalUser",
                table: "AbpUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PortalUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    GenderLkpId = table.Column<long>(nullable: false),
                    CityLkpId = table.Column<long>(nullable: false),
                    Region = table.Column<string>(maxLength: 200, nullable: false),
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
                    NationalityLkpId = table.Column<long>(nullable: false),
                    MobileNumber1 = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNumber2 = table.Column<string>(maxLength: 50, nullable: true),
                    JobDescription = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalUser_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortalUser_UserId",
                table: "PortalUser",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortalUser");

            migrationBuilder.DropColumn(
                name: "IsPortalUser",
                table: "AbpUsers");
        }
    }
}
