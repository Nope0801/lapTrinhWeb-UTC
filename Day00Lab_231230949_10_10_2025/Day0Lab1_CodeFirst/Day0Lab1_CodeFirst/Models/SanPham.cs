using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab1_CodeFirst.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string MaSanPham { get; set; }
        [Required]
        [MaxLength(150)]
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }
        public int MaLoai { get; set; }
        public bool TrangThai { get; set; }
    }
}
