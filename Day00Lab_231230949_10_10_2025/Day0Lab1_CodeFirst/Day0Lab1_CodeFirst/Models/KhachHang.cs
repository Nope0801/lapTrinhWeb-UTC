using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab1_CodeFirst.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string MaKhachHang { get; set; }
        [Required]
        [MaxLength(100)]
        public string HoTenKhachHang { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string MatKhau { get; set; }
        [Required]
        [Phone]
        public string DienThoai { get; set; }
        [Required]
        public string DiaChi { get; set; }
        public DateTime NgayDangKy { get; set; }
        public bool TrangThai { get; set; }

    }
}
