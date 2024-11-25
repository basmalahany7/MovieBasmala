using MovieBasmala.Dtos.CategoryDtos;

namespace MovieBasmala.Repos.CategoryRepos
{
    public interface ICategoryRepo
    {
        public void AddCategory(CategoryDto categorydto);
        public bool UpdateCategory(CategoryDto categorydto,int id);
    }
}
