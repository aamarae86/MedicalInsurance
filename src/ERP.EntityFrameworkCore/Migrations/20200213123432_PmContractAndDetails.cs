using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PmContractAndDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PmContract",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ContractNumber = table.Column<string>(maxLength: 30, nullable: true),
                    StatusLkpId = table.Column<long>(nullable: true),
                    PmTenantId = table.Column<long>(nullable: true),
                    ContractDate = table.Column<DateTime>(nullable: true),
                    PropertyId = table.Column<long>(nullable: true),
                    ContractStartDate = table.Column<DateTime>(nullable: true),
                    ContractEndDate = table.Column<DateTime>(nullable: true),
                    ContractEndDatePrint = table.Column<DateTime>(nullable: true),
                    PmPaymentTypeLkpId = table.Column<long>(nullable: true),
                    PmActivityLkpId = table.Column<long>(nullable: true),
                    TaxNo = table.Column<string>(maxLength: 100, nullable: true),
                    TaxPercent = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    RentAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    PmUnitTypeLkpId = table.Column<long>(nullable: true),
                    InsuranceAmount = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    ParentContractId = table.Column<long>(nullable: true),
                    Condition1 = table.Column<string>(maxLength: 4000, nullable: true),
                    Condition2 = table.Column<string>(maxLength: 4000, nullable: true),
                    Condition3 = table.Column<string>(maxLength: 4000, nullable: true),
                    Condition4 = table.Column<string>(maxLength: 4000, nullable: true),
                    Condition5 = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PmContractAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: true),
                    PmContractId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmContractAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmContractAttachments_PmContract_PmContractId",
                        column: x => x.PmContractId,
                        principalTable: "PmContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PmContractPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PmContractId = table.Column<long>(nullable: true),
                    PaymentNo = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    CheckNumber = table.Column<string>(maxLength: 30, nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    PaymentTypeLkpId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    BankLkpId = table.Column<long>(nullable: true),
                    PaymentSourceLkpID = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmContractPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmContractPayments_PmContract_PmContractId",
                        column: x => x.PmContractId,
                        principalTable: "PmContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PmContractUnitDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PropertiesUnitId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    PmContractId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmContractUnitDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmContractUnitDetails_PmContract_PmContractId",
                        column: x => x.PmContractId,
                        principalTable: "PmContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PmOtherContractPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    OtherPaymentTypesId = table.Column<long>(nullable: true),
                    PmContractId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmOtherContractPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmOtherContractPayments_PmContract_PmContractId",
                        column: x => x.PmContractId,
                        principalTable: "PmContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmContractAttachments_PmContractId",
                table: "PmContractAttachments",
                column: "PmContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContractPayments_PmContractId",
                table: "PmContractPayments",
                column: "PmContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PmContractUnitDetails_PmContractId",
                table: "PmContractUnitDetails",
                column: "PmContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PmOtherContractPayments_PmContractId",
                table: "PmOtherContractPayments",
                column: "PmContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmContractAttachments");

            migrationBuilder.DropTable(
                name: "PmContractPayments");

            migrationBuilder.DropTable(
                name: "PmContractUnitDetails");

            migrationBuilder.DropTable(
                name: "PmOtherContractPayments");

            migrationBuilder.DropTable(
                name: "PmContract");
        }
    }
}
