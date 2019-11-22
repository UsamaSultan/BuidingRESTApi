using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTExercise.api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _repository;

        public AuthorsController(ICourseLibraryRepository repository)
        {
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var results = _repository.GetAuthors();

                if (results == null) return NotFound("No result Found.");
                
                return new JsonResult(results);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
            
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAuthorsasync(Guid Id)
        {
            try
            {
                var result = _repository.GetAuthor(Id);

                if (result == null) return NotFound("No result Found.");

                return new JsonResult(result);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }

        }
    }
}
