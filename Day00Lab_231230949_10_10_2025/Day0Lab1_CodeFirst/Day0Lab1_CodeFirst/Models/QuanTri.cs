using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day0Lab1_CodeFirst.Models
{
    [Table("QuanTri")]
    public class QuanTri
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TaiKhoan { get; set; }
        [Required]
        [MaxLength(50)]
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
    }
}
