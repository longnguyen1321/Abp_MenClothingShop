using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.MenClothingShop.Migrations
{
    public partial class Added_Supplier_Clothe_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSupplierClothes",
                columns: table => new
                {
                    MaMH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNCC = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSupplierClothes", x => new { x.MaNCC, x.MaMH });
                    table.ForeignKey(
                        name: "FK_AppSupplierClothes_AppClothes_MaMH",
                        column: x => x.MaMH,
                        principalTable: "AppClothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppSupplierClothes_AppSuppliers_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "AppSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSupplierClothes_MaMH",
                table: "AppSupplierClothes",
                column: "MaMH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSupplierClothes");
        }
    }
}
