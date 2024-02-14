using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScCommitteesCheckmakeCommitteeIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteesCheck_ScCommittees_CommitteeId",
                table: "ScCommitteesCheck");

            migrationBuilder.AlterColumn<long>(
                name: "CommitteeId",
                table: "ScCommitteesCheck",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteesCheck_ScCommittees_CommitteeId",
                table: "ScCommitteesCheck",
                column: "CommitteeId",
                principalTable: "ScCommittees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteesCheck_ScCommittees_CommitteeId",
                table: "ScCommitteesCheck");

            migrationBuilder.AlterColumn<long>(
                name: "CommitteeId",
                table: "ScCommitteesCheck",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteesCheck_ScCommittees_CommitteeId",
                table: "ScCommitteesCheck",
                column: "CommitteeId",
                principalTable: "ScCommittees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
