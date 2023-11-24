using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.MenClothingShop.Migrations
{
    public partial class Made_Supplier_Name_Unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppSuppliers_TenNCC",
                table: "AppSuppliers",
                column: "TenNCC",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppSuppliers_TenNCC",
                table: "AppSuppliers");
        }
    }
}
