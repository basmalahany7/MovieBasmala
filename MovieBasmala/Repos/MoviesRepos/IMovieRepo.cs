using MovieBasmala.Dtos.MovieDtos;

namespace MovieBasmala.Repos.MoviesRepos
{
    public interface IMovieRepo
    {
        public void AddMovieWithAll(MoviePostAll moviePostAll);
        public  MoviePostAll GetById (int id);
        public List<MoviePostAll> GetAll();

    }
}
