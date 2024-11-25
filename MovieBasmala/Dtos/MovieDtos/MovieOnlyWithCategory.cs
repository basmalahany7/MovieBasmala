using MovieBasmala.Dtos.CategoryDtos;
using MovieBasmala.Models;

namespace MovieBasmala.Dtos.MovieDtos
{
    public class MovieOnlyWithCategory
    {
        public string MovieTitle { get; set; }
        public DateTime RelaseDate { get; set; }
        public CategoryDto Categorydto { get; set; }
    }
}
