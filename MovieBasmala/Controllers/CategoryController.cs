using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBasmala.Dtos.CategoryDtos;
using MovieBasmala.Repos.CategoryRepos;

namespace MovieBasmala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //this is a controller
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _repo;
        public CategoryController(ICategoryRepo repo) 
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryDto categorydto)
        {
            _repo.AddCategory(categorydto);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory (CategoryDto categorydto,int id)
        {
            var IsFound=_repo.UpdateCategory(categorydto,id);
            if(IsFound == false)
            {
                return NotFound();
            }
            else
            {
                return Accepted();
            }

        }
    }
}
