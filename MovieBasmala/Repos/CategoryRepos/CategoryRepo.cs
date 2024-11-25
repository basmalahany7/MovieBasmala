using MovieBasmala.Dtos.CategoryDtos;
using MovieBasmala.Models;

namespace MovieBasmala.Repos.CategoryRepos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context) 
        {
            _context = context;
        }
        public void AddCategory(CategoryDto categorydto)
        {
            Category category = new Category
            {
                CategoryName = categorydto.CategoryName,  
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public bool UpdateCategory(CategoryDto categorydto,int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if(category == null)
            {
                return false;
            }
            else
            {
                category.CategoryName = categorydto.CategoryName;
                _context.Categories.Update(category);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
