using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.MenClothingShop.Migrations
{
    public partial class Create_Supplier_Import_ImportDetail_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppImports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaPN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNCC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTienNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TinhTrangPX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppImports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppImports_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppSuppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNCC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DiaChiNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LienLacNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppImportDetails",
                columns: table => new
                {
                    MaPN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaMH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuongNhap = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTienNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppImportDetails", x => new { x.MaPN, x.MaMH });
                    table.ForeignKey(
                        name: "FK_AppImportDetails_AppClothes_MaMH",
                        column: x => x.MaMH,
                        principalTable: "AppClothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppImportDetails_AppImports_MaPN",
                        column: x => x.MaPN,
                        principalTable: "AppImports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppImportDetails_MaMH",
                table: "AppImportDetails",
                column: "MaMH");

            migrationBuilder.CreateIndex(
                name: "IX_AppImports_UserId",
                table: "AppImports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppImportDetails");

            migrationBuilder.DropTable(
                name: "AppSuppliers");

            migrationBuilder.DropTable(
                name: "AppImports");
        }
    }
}
