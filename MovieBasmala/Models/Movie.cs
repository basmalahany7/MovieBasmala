namespace MovieBasmala.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime RelaseDate { get; set; }
        public List<Director> Directors { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
