using MovieBasmala.Dtos.CategoryDtos;
using MovieBasmala.Dtos.DirectorDtos;
using System.ComponentModel.DataAnnotations;

namespace MovieBasmala.Dtos.MovieDtos
{
    public class MoviePostAll
    {
        [Required]
        public string MovieTitle { get; set; }
        public DateTime RelaseDate { get; set; }
        public CategoryDto CategoryDto { get; set; }
        public List<DirectorPostWithNationality>directorPostWithNationalities { get; set; }
    }
}
