using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09Lab_231230949_17_10_2025.Models
{
    [Table("HvtLoai_San_Pham")]
    [Index(nameof(hvtMaLoai), IsUnique = true)]
    public class HvtLoai_San_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long hvtId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(10)]
        public string hvtMaLoai { get; set; }

        [Display(Name = "Tên loại")]
        [StringLength(50)]
        public string hvtTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool hvtTrangThai { get; set; }

        public ICollection<HvtSan_Pham> hvtSan_Phams { get; set; } = new HashSet<HvtSan_Pham>();


    }
}
