using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class changesInCommitteeDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DecisionNotes",
                table: "ScCommitteeDetails",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StatusLkpId",
                table: "ScCommitteeDetails",
                nullable: false,
                defaultValue: 290L);

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeDetails_StatusLkpId",
                table: "ScCommitteeDetails",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_StatusLkpId",
                table: "ScCommitteeDetails",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_StatusLkpId",
                table: "ScCommitteeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ScCommitteeDetails_StatusLkpId",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "DecisionNotes",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "ScCommitteeDetails");
        }
    }
}
