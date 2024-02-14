using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class tmLocations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmLocations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    RegionId = table.Column<long>(nullable: false),
                    LocationNumber = table.Column<string>(maxLength: 30, nullable: true),
                    LocationName = table.Column<string>(maxLength: 200, nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmLocations_TmRegions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "TmRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TmLocationSub",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LocationId = table.Column<long>(nullable: false),
                    TmLocationSubNumber = table.Column<string>(maxLength: 30, nullable: true),
                    TmLocationSubName = table.Column<string>(maxLength: 200, nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmLocationSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmLocationSub_TmLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "TmLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmLocations_RegionId",
                table: "TmLocations",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TmLocationSub_LocationId",
                table: "TmLocationSub",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmLocationSub");

            migrationBuilder.DropTable(
                name: "TmLocations");
        }
    }
}
