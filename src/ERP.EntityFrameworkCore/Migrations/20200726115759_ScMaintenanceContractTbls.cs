using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ScMaintenanceContractTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScMaintenanceContract",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PostUserId = table.Column<long>(nullable: true),
                    PostTime = table.Column<DateTime>(nullable: true),
                    UnPostUserId = table.Column<long>(nullable: true),
                    UnPostTime = table.Column<DateTime>(nullable: true),
                    MaintenanceContractNumber = table.Column<string>(maxLength: 30, nullable: false),
                    MaintenanceContractDate = table.Column<DateTime>(nullable: false),
                    ScMaintenanceQuotationId = table.Column<long>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    DurationOfImplementation = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    ContractTerms = table.Column<string>(maxLength: 4000, nullable: true),
                    OtherContractTerms = table.Column<string>(maxLength: 4000, nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceContract_ScMaintenanceQuotations_ScMaintenanceQuotationId",
                        column: x => x.ScMaintenanceQuotationId,
                        principalTable: "ScMaintenanceQuotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceContract_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScMaintenanceContractPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ScMaintenanceContractId = table.Column<long>(nullable: false),
                    PayemtNo = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PaymentCondition = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenanceContractPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenanceContractPayments_ScMaintenanceContract_ScMaintenanceContractId",
                        column: x => x.ScMaintenanceContractId,
                        principalTable: "ScMaintenanceContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceContract_ScMaintenanceQuotationId",
                table: "ScMaintenanceContract",
                column: "ScMaintenanceQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceContract_StatusLkpId",
                table: "ScMaintenanceContract",
                column: "StatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenanceContractPayments_ScMaintenanceContractId",
                table: "ScMaintenanceContractPayments",
                column: "ScMaintenanceContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScMaintenanceContractPayments");

            migrationBuilder.DropTable(
                name: "ScMaintenanceContract");
        }
    }
}
