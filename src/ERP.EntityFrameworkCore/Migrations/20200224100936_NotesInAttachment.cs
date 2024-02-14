using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class NotesInAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AttachmentNameEn",
                table: "ScFndProtalAttachmentSetting",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ScFndProtalAttachmentSetting",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ScFndProtalAttachmentSetting");

            migrationBuilder.AlterColumn<string>(
                name: "AttachmentNameEn",
                table: "ScFndProtalAttachmentSetting",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
