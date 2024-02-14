using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editScCommitteeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NoOfMonths",
                table: "ScCommitteeDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "AidAmount",
                table: "ScCommitteeDetails",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AddColumn<long>(
                name: "OtherCommittee",
                table: "ScCommitteeDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherCommitteeMonthNo",
                table: "ScCommitteeDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScCommitteeDetails_OtherCommittee",
                table: "ScCommitteeDetails",
                column: "OtherCommittee");

            migrationBuilder.AddForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_OtherCommittee",
                table: "ScCommitteeDetails",
                column: "OtherCommittee",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScCommitteeDetails_FndLookupValues_OtherCommittee",
                table: "ScCommitteeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ScCommitteeDetails_OtherCommittee",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "OtherCommittee",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "OtherCommitteeMonthNo",
                table: "ScCommitteeDetails");

            migrationBuilder.AlterColumn<int>(
                name: "NoOfMonths",
                table: "ScCommitteeDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AidAmount",
                table: "ScCommitteeDetails",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);
        }
    }
}
