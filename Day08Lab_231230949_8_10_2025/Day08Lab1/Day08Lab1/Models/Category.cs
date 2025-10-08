using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day08Lab1.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Status { get; set; }
        public DateTime CreatedDate{ get; set; }
        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}
