using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class CreateAffliateAccount : Migration
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

            migrationBuilder.CreateTable(
                name: "AffliateAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Tel = table.Column<string>(maxLength: 200, nullable: true),
                    Mobile = table.Column<string>(maxLength: 200, nullable: true),
                    BankAccountNo = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 200, nullable: true),
                    Region = table.Column<string>(maxLength: 200, nullable: true),
                    BankLkpId = table.Column<long>(nullable: true),
                    CountryLkpId = table.Column<long>(nullable: true),
                    LanguageLkpId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffliateAccount", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "AffliateAccount");

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
