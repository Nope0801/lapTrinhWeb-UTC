using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab1_CodeFirst.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string MaHoaDon { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public DateTime NgayNhan { get; set; }
        [Required]
        [MaxLength(100)]
        public string HoTenKhachHang { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string DienThoai { get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTriGia { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
