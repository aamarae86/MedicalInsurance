using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTablesScCommittesesCheckAndItsDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommitteeNumber",
                table: "ScCommittees",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommitteeName",
                table: "ScCommittees",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CashingTo",
                table: "ScCommitteeDetails",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ScCommitteesCheck",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OperationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    OperationDate = table.Column<DateTime>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    CommitteeId = table.Column<long>(nullable: false),
                    FromCheckNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BankAccountId = table.Column<long>(nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCommitteesCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCommitteesCheck_ApBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "ApBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScCommitteesCheck_ScCommittees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "ScCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScCommitteesCheck_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScCommitteesCheckDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CommitteeDetailsId = table.Column<long>(nullable: true),
                    CommitteesCheckId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScCommitteesCheckDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScCommitteesCheckDetails_ScCommitteesCheck_CommitteesCheckId",
                        column: x => x.CommitteesCheckId,
                        principalTable: "ScCommitteesCheck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteesCheck_BankAccountId",
                table: "ScCommitteesCheck",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteesCheck_CommitteeId",
                table: "ScCommitteesCheck",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteesCheck_StatusLkpId",
                table: "ScCommitteesCheck",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteesCheckDetails_CommitteesCheckId",
                table: "ScCommitteesCheckDetails",
                column: "CommitteesCheckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScCommitteesCheckDetails");

            migrationBuilder.DropTable(
                name: "ScCommitteesCheck");

            migrationBuilder.AlterColumn<string>(
                name: "CommitteeNumber",
                table: "ScCommittees",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CommitteeName",
                table: "ScCommittees",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CashingTo",
                table: "ScCommitteeDetails",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
