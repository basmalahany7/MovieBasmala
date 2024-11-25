using System.ComponentModel.DataAnnotations;

namespace MovieBasmala.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
