using MovieBasmala.Dtos.NationalityDtos;
using MovieBasmala.Models;

namespace MovieBasmala.Repos.NationalityRepos
{
    public class NationalityRepo : INationalityRepo
    {
        private readonly AppDbContext _context;
        public NationalityRepo(AppDbContext context) 
        {
            _context = context;
        }
        public void AddNationality(NationalityDto nationalityDto)
        {
           Nationality nationality = new Nationality
           {
               NationalityName = nationalityDto.NationalityName,
           };
            _context.Nationalities.Add(nationality);
            _context.SaveChanges();
        }

        public bool DeleteNationality(int id)
        {
            var nationality=_context.Nationalities.FirstOrDefault(x=>x.NationalityId== id);
            if(nationality==null)
            {
                return false;
            }
            else
            {
                _context.Nationalities.Remove(nationality);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
