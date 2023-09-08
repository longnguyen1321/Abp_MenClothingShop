using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.MenClothingShop.Migrations
{
    public partial class make_clothe_name_and_size_unique_constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppClothes_TenMH",
                table: "AppClothes");

            migrationBuilder.AlterColumn<string>(
                name: "SizeMH",
                table: "AppClothes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppClothes_TenMH_SizeMH",
                table: "AppClothes",
                columns: new[] { "TenMH", "SizeMH" },
                unique: true,
                filter: "[TenMH] IS NOT NULL AND [SizeMH] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppClothes_TenMH_SizeMH",
                table: "AppClothes");

            migrationBuilder.AlterColumn<string>(
                name: "SizeMH",
                table: "AppClothes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppClothes_TenMH",
                table: "AppClothes",
                column: "TenMH",
                unique: true);
        }
    }
}
