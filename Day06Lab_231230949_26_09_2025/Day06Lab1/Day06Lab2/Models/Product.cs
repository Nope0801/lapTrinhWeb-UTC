using System.ComponentModel.DataAnnotations;

namespace Day06Lab2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Họ tên tối đa 150 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ảnh")]
        //[RegularExpression(@"^wwwroot/products/.*$", ErrorMessage = "Ảnh phải được chọn và upload vào thư mục wwwroot/products")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá chuẩn sản phẩm")]
        [Range(100000, float.MaxValue, ErrorMessage = "Giá chuẩn sản phẩm phải lớn hơn hoặc bằng 100000")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá bán sản phẩm")]
        [Range(0, float.MaxValue, ErrorMessage = "Giá bán sản phẩm không được âm")]
        //[Compare(nameof(Price), ErrorMessage = "Giá bán phải nhỏ hơn giá chuẩn 10%")]
        public float SalePrice { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm")]
        [MaxLength(1500, ErrorMessage = "Mô tả sản phẩm không được vượt quá 1500 ký tự")]
        [RegularExpression(@"^(?!.*\b(die|admin|fack)\b).*", ErrorMessage = "Mô tả không được chứa các từ nhạy cảm")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }


    }
}
