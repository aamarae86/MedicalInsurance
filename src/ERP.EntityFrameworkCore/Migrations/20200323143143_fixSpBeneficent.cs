using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixSpBeneficent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficentNameAr",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "BeneficentNameEN",
                table: "SpBeneficent");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeneficentDate",
                table: "SpBeneficent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BeneficentName",
                table: "SpBeneficent",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "SpBeneficent",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StatusLkpId",
                table: "SpBeneficent",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SpBeneficentDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    BeneficentId = table.Column<long>(nullable: false),
                    AidAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    NoOfMonths = table.Column<int>(nullable: false),
                    CashingTo = table.Column<string>(maxLength: 200, nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    DecisionNotes = table.Column<string>(maxLength: 4000, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpBeneficentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpBeneficentDetail_SpBeneficent_BeneficentId",
                        column: x => x.BeneficentId,
                        principalTable: "SpBeneficent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpBeneficentDetail_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpBeneficentMemberDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    BeneficentId = table.Column<long>(nullable: false),
                    BeneficentMemberId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpBeneficentMemberDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpBeneficentMemberDetail_SpBeneficent_BeneficentId",
                        column: x => x.BeneficentId,
                        principalTable: "SpBeneficent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpBeneficentMemberDetail_ScComityMembers_BeneficentMemberId",
                        column: x => x.BeneficentMemberId,
                        principalTable: "ScComityMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficent_StatusLkpId",
                table: "SpBeneficent",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficentDetail_BeneficentId",
                table: "SpBeneficentDetail",
                column: "BeneficentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficentDetail_StatusLkpId",
                table: "SpBeneficentDetail",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficentMemberDetail_BeneficentId",
                table: "SpBeneficentMemberDetail",
                column: "BeneficentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficentMemberDetail_BeneficentMemberId",
                table: "SpBeneficentMemberDetail",
                column: "BeneficentMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_StatusLkpId",
                table: "SpBeneficent",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_StatusLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropTable(
                name: "SpBeneficentDetail");

            migrationBuilder.DropTable(
                name: "SpBeneficentMemberDetail");

            migrationBuilder.DropIndex(
                name: "IX_SpBeneficent_StatusLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "BeneficentDate",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "BeneficentName",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "SpBeneficent");

            migrationBuilder.AddColumn<string>(
                name: "BeneficentNameAr",
                table: "SpBeneficent",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficentNameEN",
                table: "SpBeneficent",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
