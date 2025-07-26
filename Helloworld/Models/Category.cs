using System.ComponentModel.DataAnnotations;

namespace Helloworld.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } //Id sẽ là khóa chính của bảng Category
        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(10, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; } //Name là tên của danh mục, bắt buộc phải có
        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100")]
        public string DisplayOrder { get; set; }
    }
}
