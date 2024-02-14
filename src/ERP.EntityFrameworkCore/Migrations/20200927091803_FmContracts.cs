using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FmContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FmContracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ContractNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PaymentTypeLkpId = table.Column<long>(nullable: false),
                    ContractDate = table.Column<DateTime>(nullable: false),
                    VendorId = table.Column<long>(nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    AccountCode = table.Column<long>(nullable: false),
                    AnnualAmount = table.Column<decimal>(nullable: false),
                    RentAmount = table.Column<decimal>(nullable: false),
                    VendorContractNumber = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    AdvAccountCode = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmContracts_FndLookupValues_PaymentTypeLkpId",
                        column: x => x.PaymentTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FmContracts_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FmBuildingsContracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ContractId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PmPropertiesId = table.Column<long>(nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmBuildingsContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmBuildingsContracts_FmContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "FmContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FmBuildingsContracts_PmProperties_PmPropertiesId",
                        column: x => x.PmPropertiesId,
                        principalTable: "PmProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FmContractVisits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ContractId = table.Column<long>(nullable: false),
                    VisitNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    EngineerId = table.Column<long>(nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmContractVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmContractVisits_FmContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "FmContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FmContractVisits_FmEngineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "FmEngineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FmBuildingsContracts_ContractId",
                table: "FmBuildingsContracts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_FmBuildingsContracts_PmPropertiesId",
                table: "FmBuildingsContracts",
                column: "PmPropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_FmContracts_PaymentTypeLkpId",
                table: "FmContracts",
                column: "PaymentTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FmContracts_StatusLkpId",
                table: "FmContracts",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_FmContractVisits_ContractId",
                table: "FmContractVisits",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_FmContractVisits_EngineerId",
                table: "FmContractVisits",
                column: "EngineerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FmBuildingsContracts");

            migrationBuilder.DropTable(
                name: "FmContractVisits");

            migrationBuilder.DropTable(
                name: "FmContracts");
        }
    }
}
