﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTmRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmRegions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CityLkpId = table.Column<long>(nullable: false),
                    RegionNumber = table.Column<string>(maxLength: 30, nullable: true),
                    RegionName = table.Column<string>(maxLength: 200, nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmRegions_FndLookupValues_CityLkpId",
                        column: x => x.CityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TmRegions_CityLkpId",
                table: "TmRegions",
                column: "CityLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmRegions");
        }
    }
}
