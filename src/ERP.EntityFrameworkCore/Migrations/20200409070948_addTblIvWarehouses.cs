using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addTblIvWarehouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IvWarehouses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    WarehouseNumber = table.Column<string>(maxLength: 20, nullable: false),
                    WarehouseName = table.Column<string>(maxLength: 200, nullable: false),
                    CityLkpId = table.Column<long>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    WarehouseAddress = table.Column<string>(maxLength: 200, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IvWarehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IvWarehouses_FndLookupValues_CityLkpId",
                        column: x => x.CityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IvWarehouses_CityLkpId",
                table: "IvWarehouses",
                column: "CityLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IvWarehouses");
        }
    }
}
