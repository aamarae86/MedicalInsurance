using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_ArJobCardHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //JobNumber
            //JobDate
            //StartDate
            //VehiclePlateNo
            //VehicleType
            //ArCustomerId

            //EstimatedAmount
            //VehicleEmirateLkpId
            //VehicleMakeLkpId
            //VehicleModelLkpId
            //VehicleColorLkpId
            //JobTypeLkpId

            migrationBuilder.CreateTable(
                name: "ArJobCardHd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    JobNumber = table.Column<string>(maxLength: 30, nullable: false),
                    JobDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    JobTypeLkpId = table.Column<long>(nullable: false),
                    ArCustomerId = table.Column<long>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 200, nullable: true),
                    ContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    VehiclePlateNo = table.Column<string>(maxLength: 50, nullable: false),
                    VehicleEmirateLkpId = table.Column<long>(nullable: false),
                    VehicleMakeLkpId = table.Column<long>(nullable: false),
                    VehicleType = table.Column<string>(maxLength: 50, nullable: false),
                    VehicleModelLkpId = table.Column<long>(nullable: false),
                    VehicleColorLkpId = table.Column<long>(nullable: false),
                    EstimatedAmount = table.Column<decimal>(nullable: false),
                    ClaimNo = table.Column<string>(maxLength: 200, nullable: true),
                    LpoNo = table.Column<string>(maxLength: 200, nullable: true),
                    OriginalAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CustomerVatPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CustomerVatAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    ExcessStatusLkpId = table.Column<long>(nullable: false),
                    ExcessAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    ExcessVatPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    ExcessVatAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArJobCardHd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArJobCardHd_ArCustomers_ArCustomerId",
                        column: x => x.ArCustomerId,
                        principalTable: "ArCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArJobCardHd_FndLookupValues_ExcessStatusLkpId",
                        column: x => x.ExcessStatusLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArJobCardHd_FndLookupValues_JobTypeLkpId",
                        column: x => x.JobTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArJobCardHd_FndLookupValues_VehicleColorLkpId",
                        column: x => x.VehicleColorLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
                        column: x => x.VehicleEmirateLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArJobCardHd_FndLookupValues_VehicleMakeLkpId",
                        column: x => x.VehicleMakeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArJobCardHd_FndLookupValues_VehicleModelLkpId",
                        column: x => x.VehicleModelLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArJobCardAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(nullable: false),
                    ArJobCardHdId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArJobCardAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArJobCardAttachments_ArJobCardHd_ArJobCardHdId",
                        column: x => x.ArJobCardHdId,
                        principalTable: "ArJobCardHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardAttachments_ArJobCardHdId",
                table: "ArJobCardAttachments",
                column: "ArJobCardHdId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_ArCustomerId",
                table: "ArJobCardHd",
                column: "ArCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_ExcessStatusLkpId",
                table: "ArJobCardHd",
                column: "ExcessStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_JobTypeLkpId",
                table: "ArJobCardHd",
                column: "JobTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_VehicleColorLkpId",
                table: "ArJobCardHd",
                column: "VehicleColorLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_VehicleEmirateLkpId",
                table: "ArJobCardHd",
                column: "VehicleEmirateLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_VehicleMakeLkpId",
                table: "ArJobCardHd",
                column: "VehicleMakeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArJobCardHd_VehicleModelLkpId",
                table: "ArJobCardHd",
                column: "VehicleModelLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArJobCardAttachments");

            migrationBuilder.DropTable(
                name: "ArJobCardHd");
        }
    }
}
