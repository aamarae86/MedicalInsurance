using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fix_glCodeCom_accDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute1",
                table: "GlCodeComDetails",
                column: "Attribute1");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute2",
                table: "GlCodeComDetails",
                column: "Attribute2");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute3",
                table: "GlCodeComDetails",
                column: "Attribute3");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute4",
                table: "GlCodeComDetails",
                column: "Attribute4");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute5",
                table: "GlCodeComDetails",
                column: "Attribute5");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute6",
                table: "GlCodeComDetails",
                column: "Attribute6");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute7",
                table: "GlCodeComDetails",
                column: "Attribute7");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute8",
                table: "GlCodeComDetails",
                column: "Attribute8");

            migrationBuilder.CreateIndex(
                name: "IX_GlCodeComDetails_Attribute9",
                table: "GlCodeComDetails",
                column: "Attribute9");

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute1",
                table: "GlCodeComDetails",
                column: "Attribute1",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute2",
                table: "GlCodeComDetails",
                column: "Attribute2",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute3",
                table: "GlCodeComDetails",
                column: "Attribute3",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute4",
                table: "GlCodeComDetails",
                column: "Attribute4",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute5",
                table: "GlCodeComDetails",
                column: "Attribute5",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute6",
                table: "GlCodeComDetails",
                column: "Attribute6",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute7",
                table: "GlCodeComDetails",
                column: "Attribute7",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute8",
                table: "GlCodeComDetails",
                column: "Attribute8",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute9",
                table: "GlCodeComDetails",
                column: "Attribute9",
                principalTable: "GlAccDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute1",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute2",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute3",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute4",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute5",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute6",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute7",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute8",
                table: "GlCodeComDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GlCodeComDetails_GlAccDetails_Attribute9",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute1",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute2",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute3",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute4",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute5",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute6",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute7",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute8",
                table: "GlCodeComDetails");

            migrationBuilder.DropIndex(
                name: "IX_GlCodeComDetails_Attribute9",
                table: "GlCodeComDetails");
        }
    }
}
