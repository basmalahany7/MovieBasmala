using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBasmala.Dtos.MovieDtos;
using MovieBasmala.Repos.MoviesRepos;

namespace MovieBasmala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _repo;
        public MovieController(IMovieRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddMovieWithAll(MoviePostAll moviePostAll)
        {
            _repo.AddMovieWithAll(moviePostAll);
            return Created();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var isFound=_repo.GetAll();
            if(isFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(isFound);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) { 
            var isFound=_repo.GetById(id);
            if(isFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(isFound); 
            }
        }
    }
}
