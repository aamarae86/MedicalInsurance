using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteesCheckDetails_CommitteeDetailsId",
                table: "ScCommitteesCheckDetails",
                column: "CommitteeDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteesCheckDetails_ScCommitteeDetails_CommitteeDetailsId",
                table: "ScCommitteesCheckDetails",
                column: "CommitteeDetailsId",
                principalTable: "ScCommitteeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteesCheckDetails_ScCommitteeDetails_CommitteeDetailsId",
                table: "ScCommitteesCheckDetails");

            migrationBuilder.DropIndex(
                name: "IX_ScCommitteesCheckDetails_CommitteeDetailsId",
                table: "ScCommitteesCheckDetails");
        }
    }
}
