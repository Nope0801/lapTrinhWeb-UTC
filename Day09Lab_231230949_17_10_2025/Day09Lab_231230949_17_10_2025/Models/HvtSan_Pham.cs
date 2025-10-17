using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_231230949_17_10_2025.Models
{
    [Table("HvtSan_Pham")]
    public class HvtSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long hvtId { get; set; }

        [Display(Name = "Mã sản phẩmm")]
        [Required]
        [StringLength(10)]
        public string hvtMaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string hvtTenSanPham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string hvtHinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int hvtSoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal hvtDonGia { get; set; }

        public long hvtLoaiSanPhamId { get; set; }

        public HvtLoai_San_Pham? hvtLoai_San_Pham { get; set; }

    }
}
