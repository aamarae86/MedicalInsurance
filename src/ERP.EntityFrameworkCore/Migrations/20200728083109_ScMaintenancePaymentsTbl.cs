using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ScMaintenancePaymentsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScMaintenancePayments",
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
                    MaintenancePaymentNumber = table.Column<string>(maxLength: 30, nullable: false),
                    MaintenancePaymentDate = table.Column<DateTime>(nullable: false),
                    StatusLkpId = table.Column<long>(nullable: false),
                    ScMaintenanceContractPaymentId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    AchievementRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMaintenancePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScMaintenancePayments_ScMaintenanceContractPayments_ScMaintenanceContractPaymentId",
                        column: x => x.ScMaintenanceContractPaymentId,
                        principalTable: "ScMaintenanceContractPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScMaintenancePayments_FndLookupValues_StatusLkpId",
                        column: x => x.StatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenancePayments_ScMaintenanceContractPaymentId",
                table: "ScMaintenancePayments",
                column: "ScMaintenanceContractPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMaintenancePayments_StatusLkpId",
                table: "ScMaintenancePayments",
                column: "StatusLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScMaintenancePayments");
        }
    }
}
