using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab1_CodeFirst.Models
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuongMua { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGiaMua { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ThanhTien { get; set; }
        public bool TrangThai { get; set; }
    }
}
