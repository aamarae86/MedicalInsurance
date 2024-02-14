using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editFmMaintRequisitionsExe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmEngineers_EngineerId",
                table: "FmMaintRequisitionsExe");

            migrationBuilder.DropForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContractVisits_FmContractVisitsId",
                table: "FmMaintRequisitionsExe");

            migrationBuilder.DropForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContracts_FmContractsId",
                table: "FmMaintRequisitionsExe");

            migrationBuilder.AlterColumn<long>(
                name: "FmContractsId",
                table: "FmMaintRequisitionsExe",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "FmContractVisitsId",
                table: "FmMaintRequisitionsExe",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "EngineerId",
                table: "FmMaintRequisitionsExe",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmEngineers_EngineerId",
                table: "FmMaintRequisitionsExe",
                column: "EngineerId",
                principalTable: "FmEngineers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContractVisits_FmContractVisitsId",
                table: "FmMaintRequisitionsExe",
                column: "FmContractVisitsId",
                principalTable: "FmContractVisits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContracts_FmContractsId",
                table: "FmMaintRequisitionsExe",
                column: "FmContractsId",
                principalTable: "FmContracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmEngineers_EngineerId",
                table: "FmMaintRequisitionsExe");

            migrationBuilder.DropForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContractVisits_FmContractVisitsId",
                table: "FmMaintRequisitionsExe");

            migrationBuilder.DropForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContracts_FmContractsId",
                table: "FmMaintRequisitionsExe");

            migrationBuilder.AlterColumn<long>(
                name: "FmContractsId",
                table: "FmMaintRequisitionsExe",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FmContractVisitsId",
                table: "FmMaintRequisitionsExe",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EngineerId",
                table: "FmMaintRequisitionsExe",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmEngineers_EngineerId",
                table: "FmMaintRequisitionsExe",
                column: "EngineerId",
                principalTable: "FmEngineers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContractVisits_FmContractVisitsId",
                table: "FmMaintRequisitionsExe",
                column: "FmContractVisitsId",
                principalTable: "FmContractVisits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FmMaintRequisitionsExe_FmContracts_FmContractsId",
                table: "FmMaintRequisitionsExe",
                column: "FmContractsId",
                principalTable: "FmContracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
