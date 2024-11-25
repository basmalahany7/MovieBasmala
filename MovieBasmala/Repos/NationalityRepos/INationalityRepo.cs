using MovieBasmala.Dtos.NationalityDtos;

namespace MovieBasmala.Repos.NationalityRepos
{
    public interface INationalityRepo
    {
        public void AddNationality(NationalityDto nationalityDto);
        public bool DeleteNationality(int id);
    }
}
