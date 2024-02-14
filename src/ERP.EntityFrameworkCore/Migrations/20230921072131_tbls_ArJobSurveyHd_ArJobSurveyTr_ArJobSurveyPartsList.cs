using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class tbls_ArJobSurveyHd_ArJobSurveyTr_ArJobSurveyPartsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArJobSurveyHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ClaimNo = table.Column<string>(maxLength: 30, nullable: false),
                    ClaimDate = table.Column<DateTime>(nullable: false),
                    InsuredVehicle = table.Column<bool>(nullable: false),
                    TPVehicle = table.Column<bool>(nullable: false),
                    VehicleMakeLkpId = table.Column<long>(nullable: true),
                    VehicleModelLkpId = table.Column<long>(nullable: true),
                    ArJobSurveyStatusLkpId = table.Column<long>(nullable: true),
                    PlateNo = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArJobSurveyHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArJobSurveyHd_FndLookupValues_ArJobSurveyStatusLkpId",
                        column: x => x.ArJobSurveyStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArJobSurveyHd_FndLookupValues_VehicleMakeLkpId",
                        column: x => x.VehicleMakeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArJobSurveyHd_FndLookupValues_VehicleModelLkpId",
                        column: x => x.VehicleModelLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArJobSurveyPartsList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PartsNumber = table.Column<string>(maxLength: 30, nullable: false),
                    PartsName = table.Column<string>(nullable: false),
                    PartsCategoryLkpId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArJobSurveyPartsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArJobSurveyPartsList_FndLookupValues_PartsCategoryLkpId",
                        column: x => x.PartsCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArJobSurveyTr",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    ArJobSurveyHdId = table.Column<long>(nullable: true),
                    ArJobSurveyPartsId = table.Column<long>(nullable: true),
                    PartsCategoryLkpId = table.Column<long>(nullable: true),
                    IsRepair = table.Column<bool>(nullable: false),
                    IsReplace = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArJobSurveyTr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArJobSurveyTr_ArJobSurveyHd_ArJobSurveyHdId",
                        column: x => x.ArJobSurveyHdId,
                        principalTable: "ArJobSurveyHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArJobSurveyTr_ArJobSurveyPartsList_ArJobSurveyPartsId",
                        column: x => x.ArJobSurveyPartsId,
                        principalTable: "ArJobSurveyPartsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArJobSurveyTr_FndLookupValues_PartsCategoryLkpId",
                        column: x => x.PartsCategoryLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyHd_ArJobSurveyStatusLkpId",
                table: "ArJobSurveyHd",
                column: "ArJobSurveyStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyHd_VehicleMakeLkpId",
                table: "ArJobSurveyHd",
                column: "VehicleMakeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyHd_VehicleModelLkpId",
                table: "ArJobSurveyHd",
                column: "VehicleModelLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyPartsList_PartsCategoryLkpId",
                table: "ArJobSurveyPartsList",
                column: "PartsCategoryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyTr_ArJobSurveyHdId",
                table: "ArJobSurveyTr",
                column: "ArJobSurveyHdId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyTr_ArJobSurveyPartsId",
                table: "ArJobSurveyTr",
                column: "ArJobSurveyPartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobSurveyTr_PartsCategoryLkpId",
                table: "ArJobSurveyTr",
                column: "PartsCategoryLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArJobSurveyTr");

            migrationBuilder.DropTable(
                name: "ArJobSurveyHd");

            migrationBuilder.DropTable(
                name: "ArJobSurveyPartsList");
        }
    }
}
