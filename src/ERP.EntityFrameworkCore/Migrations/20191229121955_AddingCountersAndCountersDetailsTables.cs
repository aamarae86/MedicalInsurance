using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddingCountersAndCountersDetailsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CounterName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CounterTypeLkp = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountersDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CounterId = table.Column<long>(nullable: false),
                    Value = table.Column<long>(nullable: false),
                    Year = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountersDetails_Counters_CounterId",
                        column: x => x.CounterId,
                        principalTable: "Counters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArCustomers_CustomerTypeLkpId",
                table: "ArCustomers",
                column: "CustomerTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CountersDetails_CounterId",
                table: "CountersDetails",
                column: "CounterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArCustomers_FndLookupValues_CustomerTypeLkpId",
                table: "ArCustomers",
                column: "CustomerTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArCustomers_FndLookupValues_CustomerTypeLkpId",
                table: "ArCustomers");

            migrationBuilder.DropTable(
                name: "CountersDetails");

            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropIndex(
                name: "IX_ArCustomers_CustomerTypeLkpId",
                table: "ArCustomers");
        }
    }
}
