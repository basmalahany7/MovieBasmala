using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBasmala.Dtos.NationalityDtos;
using MovieBasmala.Repos.NationalityRepos;

namespace MovieBasmala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityRepo _repo;
        public NationalityController(INationalityRepo repo) 
        {
           _repo = repo;
        }
        [HttpPost]
        public IActionResult AddNationality(NationalityDto nationalityDto)
        {
            _repo.AddNationality(nationalityDto);
            return Created();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNationality (int id)
        {
            var isFound=_repo.DeleteNationality(id);
            if(isFound==false)
            {
                return NotFound();
            }
            else
            {
                return  NoContent();
            }

        }
    }
}
