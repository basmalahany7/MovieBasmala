using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBasmala.Dtos.DirectorDtos;
using MovieBasmala.Repos.DirectorRepos;

namespace MovieBasmala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepo _repo;
        public DirectorController(IDirectorRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Add(DirectorPostWithNationality directorPostWithNationality)
        {
             _repo.AddDirector(directorPostWithNationality);
            return Created();

        }
        [HttpPut("{id}")]
        public IActionResult UpdateAll(DirectorUpdateWithAll directorUpdateWithAll,int id)
        {
            var isFound=_repo.UpdateAll(directorUpdateWithAll,id);
            if(isFound==false)
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
