using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day09Lab_231230949_17_10_2025.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HvtLoai_San_Pham",
                columns: table => new
                {
                    hvtId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hvtMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    hvtTenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hvtTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HvtLoai_San_Pham", x => x.hvtId);
                });

            migrationBuilder.CreateTable(
                name: "HvtSan_Pham",
                columns: table => new
                {
                    hvtId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hvtMaSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    hvtTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hvtHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hvtSoLuong = table.Column<int>(type: "int", nullable: false),
                    hvtDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    hvtLoaiSanPhamId = table.Column<long>(type: "bigint", nullable: false),
                    hvtLoai_San_PhamhvtId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HvtSan_Pham", x => x.hvtId);
                    table.ForeignKey(
                        name: "FK_HvtSan_Pham_HvtLoai_San_Pham_hvtLoai_San_PhamhvtId",
                        column: x => x.hvtLoai_San_PhamhvtId,
                        principalTable: "HvtLoai_San_Pham",
                        principalColumn: "hvtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HvtLoai_San_Pham_hvtMaLoai",
                table: "HvtLoai_San_Pham",
                column: "hvtMaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HvtSan_Pham_hvtLoai_San_PhamhvtId",
                table: "HvtSan_Pham",
                column: "hvtLoai_San_PhamhvtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HvtSan_Pham");

            migrationBuilder.DropTable(
                name: "HvtLoai_San_Pham");
        }
    }
}
