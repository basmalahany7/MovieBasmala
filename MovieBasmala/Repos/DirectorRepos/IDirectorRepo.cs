using MovieBasmala.Dtos.DirectorDtos;

namespace MovieBasmala.Repos.DirectorRepos
{
    public interface IDirectorRepo
    {
        public void AddDirector(DirectorPostWithNationality directorPostWithNationality);
        public bool UpdateAll(DirectorUpdateWithAll directorUpdateWithAll,int id);
    }
}
