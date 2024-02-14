using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class foreignkeys : Migration
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

            migrationBuilder.AddColumn<long>(
                name: "ScPortalRequestStudyId",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CashingTo",
                table: "ScCommitteeDetails",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScCommittees_ScPortalRequestStudyId",
                table: "ScCommittees",
                column: "ScPortalRequestStudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommittees_ScPortalRequestStudy_ScPortalRequestStudyId",
                table: "ScCommittees",
                column: "ScPortalRequestStudyId",
                principalTable: "ScPortalRequestStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommittees_ScPortalRequestStudy_ScPortalRequestStudyId",
                table: "ScCommittees");

            migrationBuilder.DropIndex(
                name: "IX_ScCommittees_ScPortalRequestStudyId",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "ScPortalRequestStudyId",
                table: "ScCommittees");

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
