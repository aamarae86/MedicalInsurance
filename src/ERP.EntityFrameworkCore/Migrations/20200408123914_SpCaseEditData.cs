using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class SpCaseEditData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpCaseEditData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpContractDetailsId = table.Column<long>(nullable: true),
                    OldAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    NewAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    OldSponsFor = table.Column<string>(maxLength: 200, nullable: true),
                    NewSponsFor = table.Column<string>(maxLength: 200, nullable: true),
                    OldAccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    NewAccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    OldAccountOwnerName = table.Column<string>(maxLength: 200, nullable: true),
                    NewAccountOwnerName = table.Column<string>(maxLength: 200, nullable: true),
                    OldBankLkpId = table.Column<long>(nullable: true),
                    NewBankLkpId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpCaseEditData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpCaseEditData");
        }
    }
}
