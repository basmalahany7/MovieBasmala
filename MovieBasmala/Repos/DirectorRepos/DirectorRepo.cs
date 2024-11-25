using Microsoft.EntityFrameworkCore;
using MovieBasmala.Dtos.CategoryDtos;
using MovieBasmala.Dtos.DirectorDtos;
using MovieBasmala.Dtos.MovieDtos;
using MovieBasmala.Dtos.NationalityDtos;
using MovieBasmala.Models;

namespace MovieBasmala.Repos.DirectorRepos
{
    public class DirectorRepo : IDirectorRepo
    {
        private readonly AppDbContext _context;
        public DirectorRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddDirector(DirectorPostWithNationality directorPostWithNationality)
        {
            Director director = new Director
            {
                DirectorName=directorPostWithNationality.DirectorName,
                DirectorEmail=directorPostWithNationality.DirectorEmail,
                DirectorPhone=directorPostWithNationality.DirectorPhone,
               Nationality=new Nationality
               {
                   NationalityName=directorPostWithNationality.Nationalitydto.NationalityName,
               }
              };
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public bool UpdateAll(DirectorUpdateWithAll directorUpdateWithAll, int id)
        {
           var director=_context.Directors.Include(x => x.Nationality).Include(x=>x.Movies).ThenInclude(x=>x.Category).FirstOrDefault(x=>x.DirectorId==id);
           if(director==null)
            {
                return false;
            }
            else
            {
                director.DirectorName = directorUpdateWithAll.DirectorName;
                director.DirectorEmail = directorUpdateWithAll.DirectorEmail;
                director.DirectorPhone = directorUpdateWithAll.DirectorPhone;
                director.Nationality = new Nationality
                {
                    NationalityName = directorUpdateWithAll.Nationalitydto.NationalityName,
                };

                director.Movies = directorUpdateWithAll.Moviewithcategorydto.Select(x => new Movie
                {
                    MovieTitle = x.MovieTitle,
                    RelaseDate = x.RelaseDate,
                    Category = new Category
                    {
                        CategoryName = x.Categorydto.CategoryName,
                    }
                }).ToList();
                _context.Directors.Update(director);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
