using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class CommitteesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "FilePath",
            //    table: "ScPortalRequestStudyAttachment",
            //    type: "nvarchar(1000)",
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(100  0)",
            //    oldMaxLength: 1000,
            //    oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ScCommittees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    CommitteeNumber = table.Column<string>(maxLength: 30, nullable: true),
                    CommitteeDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    CommitteeName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCommittees_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScCommitteeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    CommitteeId = table.Column<long>(nullable: false),
                    RequestStudyId = table.Column<long>(nullable: false),
                    AidAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    NoOfMonths = table.Column<int>(nullable: false),
                    CashingTo = table.Column<string>(maxLength: 200, nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCommitteeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCommitteeDetails_ScCommittees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "ScCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScCommitteeDetails_ScPortalRequestStudy_RequestStudyId",
                        column: x => x.RequestStudyId,
                        principalTable: "ScPortalRequestStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScCommitteeMemberDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    CommitteeId = table.Column<long>(nullable: false),
                    CommitteeMemberId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCommitteeMemberDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCommitteeMemberDetail_ScCommittees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "ScCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScCommitteeMemberDetail_ScComityMembers_CommitteeMemberId",
                        column: x => x.CommitteeMemberId,
                        principalTable: "ScComityMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeDetails_CommitteeId",
                table: "ScCommitteeDetails",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeDetails_RequestStudyId",
                table: "ScCommitteeDetails",
                column: "RequestStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeMemberDetail_CommitteeId",
                table: "ScCommitteeMemberDetail",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeMemberDetail_CommitteeMemberId",
                table: "ScCommitteeMemberDetail",
                column: "CommitteeMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommittees_StatusLkpId",
                table: "ScCommittees",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScCommitteeDetails");

            migrationBuilder.DropTable(
                name: "ScCommitteeMemberDetail");

            migrationBuilder.DropTable(
                name: "ScCommittees");

            //migrationBuilder.AlterColumn<string>(
            //    name: "FilePath",
            //    table: "ScPortalRequestStudyAttachment",
            //    type: "nvarchar(100  0)",
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(1000)",
            //    oldMaxLength: 1000,
            //    oldNullable: true);
        }
    }
}
