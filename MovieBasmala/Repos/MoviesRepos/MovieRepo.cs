using Microsoft.EntityFrameworkCore;
using MovieBasmala.Dtos.CategoryDtos;
using MovieBasmala.Dtos.DirectorDtos;
using MovieBasmala.Dtos.MovieDtos;
using MovieBasmala.Dtos.NationalityDtos;
using MovieBasmala.Models;
using System.Reflection.Metadata.Ecma335;

namespace MovieBasmala.Repos.MoviesRepos
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext _context;
        public MovieRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovieWithAll(MoviePostAll moviePostAll)
        {
            Movie movie = new Movie
            {
                MovieTitle = moviePostAll.MovieTitle,
                RelaseDate = moviePostAll.RelaseDate,
                Category = new Category
                {
                    CategoryName = moviePostAll.CategoryDto.CategoryName,
                },
                Directors = moviePostAll.directorPostWithNationalities.Select(x => new Director
                {
                    DirectorName = x.DirectorName,
                    DirectorEmail = x.DirectorEmail,
                    DirectorPhone = x.DirectorPhone,
                    Nationality = new Nationality
                    {
                        NationalityName = x.Nationalitydto.NationalityName,
                    }
                }).ToList(),
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();

        }

        public List<MoviePostAll> GetAll()
        {
            var allmovie = _context.Movies.Include(x => x.Category).Include(x => x.Directors).ThenInclude(x => x.Nationality).Select(x => new MoviePostAll
            {
                MovieTitle = x.MovieTitle,
                RelaseDate = x.RelaseDate,
                CategoryDto = new CategoryDto
                {
                    CategoryName = x.Category.CategoryName,
                },
                directorPostWithNationalities = x.Directors.Select(x => new DirectorPostWithNationality
                {
                    DirectorName = x.DirectorName,
                    DirectorEmail = x.DirectorEmail,
                    DirectorPhone = x.DirectorPhone,
                    Nationalitydto = new NationalityDto
                    {
                        NationalityName = x.Nationality.NationalityName,
                    }
                }).ToList(),
            }).ToList();
            return allmovie;
        }

        public MoviePostAll GetById(int id)
        {
            var movie = _context.Movies.Include(x => x.Category).Include(x => x.Directors).ThenInclude(x => x.Nationality).FirstOrDefault(x => x.MovieId == id);
            if (movie == null)
            {
                return null;
            }
            else
            {
                return new MoviePostAll
                {
                    MovieTitle = movie.MovieTitle,
                    RelaseDate = movie.RelaseDate,
                    CategoryDto = new CategoryDto
                    {
                        CategoryName = movie.Category.CategoryName,
                    },
                    directorPostWithNationalities = movie.Directors.Select(x => new DirectorPostWithNationality
                    {
                        DirectorName = x.DirectorName,
                        DirectorEmail = x.DirectorEmail,
                        DirectorPhone = x.DirectorPhone,
                        Nationalitydto = new NationalityDto
                        {
                            NationalityName = x.Nationality.NationalityName,
                        }
                    }).ToList(),
                };
            }
          
        }
    }
}
