using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.MenClothingShop.Migrations
{
    public partial class make_clothe_name_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppClothes_TenMH",
                table: "AppClothes",
                column: "TenMH",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppClothes_TenMH",
                table: "AppClothes");
        }
    }
}
