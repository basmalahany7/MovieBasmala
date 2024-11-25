namespace MovieBasmala.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string DirectorName { get; set;}
        public string DirectorPhone { get; set;}
        public string DirectorEmail { get; set;}
        public List<Movie> Movies { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
    }
}
