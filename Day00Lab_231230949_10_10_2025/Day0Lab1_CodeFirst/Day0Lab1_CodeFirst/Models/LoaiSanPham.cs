using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab1_CodeFirst.Models
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string MaLoai { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
        public bool TrangThai { get; set; }
        public ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}
