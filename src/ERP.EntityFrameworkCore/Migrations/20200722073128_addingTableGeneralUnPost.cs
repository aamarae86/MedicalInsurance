using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingTableGeneralUnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "GeneralUnPost",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    UnPostNo = table.Column<string>(maxLength: 30, nullable: true),
                    UnPostDate = table.Column<DateTime>(nullable: false),
                    SourceLkpId = table.Column<long>(nullable: false),
                    SourceId = table.Column<long>(nullable: false),
                    SourceNo = table.Column<string>(maxLength: 30, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralUnPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralUnPost_FndLookupValues_SourceLkpId",
                        column: x => x.SourceLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_SourceLkpId",
                table: "GeneralUnPost",
                column: "SourceLkpId");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "GeneralUnPost");

           
        }
    }
}
