using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addNewTblsTmCharityBoxCollect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmCharityBoxCollect",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CollectDate = table.Column<DateTime>(nullable: false),
                    CollectNumber = table.Column<string>(maxLength: 30, nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Value25F = table.Column<long>(nullable: true),
                    Value50F = table.Column<long>(nullable: true),
                    Value1Dh = table.Column<long>(nullable: true),
                    Value5Dh = table.Column<long>(nullable: true),
                    Value10Dh = table.Column<long>(nullable: true),
                    Value20Dh = table.Column<long>(nullable: true),
                    Value50Dh = table.Column<long>(nullable: true),
                    Value100Dh = table.Column<long>(nullable: true),
                    Value200Dh = table.Column<long>(nullable: true),
                    Value500Dh = table.Column<long>(nullable: true),
                    Value1000Dh = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: false),
                    BankAccountId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxCollect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxCollect_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxCollect_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TmCharityBoxCollectDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TmCharityBoxCollectId = table.Column<long>(nullable: false),
                    CharityBoxActionDetailId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxCollectDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxCollectDetails_TmCharityBoxActionDetails_CharityBoxActionDetailId",
                        column: x => x.CharityBoxActionDetailId,
                        principalTable: "TmCharityBoxActionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxCollectDetails_TmCharityBoxCollect_TmCharityBoxCollectId",
                        column: x => x.TmCharityBoxCollectId,
                        principalTable: "TmCharityBoxCollect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TmCharityBoxCollectMembersDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TmCharityBoxCollectId = table.Column<long>(nullable: false),
                    TmCharityBoxCollectMemberId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmCharityBoxCollectMembersDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxCollectMembersDetail_TmCharityBoxCollect_TmCharityBoxCollectId",
                        column: x => x.TmCharityBoxCollectId,
                        principalTable: "TmCharityBoxCollect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmCharityBoxCollectMembersDetail_TmCharityBoxCollectMembers_TmCharityBoxCollectMemberId",
                        column: x => x.TmCharityBoxCollectMemberId,
                        principalTable: "TmCharityBoxCollectMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxCollect_BankAccountId",
                table: "TmCharityBoxCollect",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxCollect_StatusLkpId",
                table: "TmCharityBoxCollect",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxCollectDetails_CharityBoxActionDetailId",
                table: "TmCharityBoxCollectDetails",
                column: "CharityBoxActionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxCollectDetails_TmCharityBoxCollectId",
                table: "TmCharityBoxCollectDetails",
                column: "TmCharityBoxCollectId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxCollectMembersDetail_TmCharityBoxCollectId",
                table: "TmCharityBoxCollectMembersDetail",
                column: "TmCharityBoxCollectId");

            migrationBuilder.CreateIndex(
                name: "IX_TmCharityBoxCollectMembersDetail_TmCharityBoxCollectMemberId",
                table: "TmCharityBoxCollectMembersDetail",
                column: "TmCharityBoxCollectMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmCharityBoxCollectDetails");

            migrationBuilder.DropTable(
                name: "TmCharityBoxCollectMembersDetail");

            migrationBuilder.DropTable(
                name: "TmCharityBoxCollect");
        }
    }
}
