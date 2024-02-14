using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ThreeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArSecurityDepositInterface",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SecurityDepositInterfaceNumber = table.Column<string>(maxLength: 30, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    ArCustomerId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    FineAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    FineAccountId = table.Column<long>(nullable: true),
                    SourceCodeLkpId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArSecurityDepositInterface", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PmCancellationContracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CancellationNumber = table.Column<string>(maxLength: 30, nullable: true),
                    CancellationDate = table.Column<DateTime>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    PmContractId = table.Column<long>(nullable: true),
                    FinePeriodPerDays = table.Column<int>(nullable: true),
                    FineAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    AccountId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmCancellationContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PmTerminateContracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PmContractId = table.Column<long>(nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    TerminationDate = table.Column<DateTime>(nullable: true),
                    TerminationNumber = table.Column<string>(maxLength: 30, nullable: true),
                    FineAmount = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    IsTransferDepositToCustomer = table.Column<bool>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmTerminateContracts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArSecurityDepositInterface");

            migrationBuilder.DropTable(
                name: "PmCancellationContracts");

            migrationBuilder.DropTable(
                name: "PmTerminateContracts");
        }
    }
}
