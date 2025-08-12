using Avenga.NotesAndTagsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.NotesAndTagsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet] //http://localhost:[port]/api/notes
        public ActionResult<List<Note>> Get()
        {
            try
            {
                return Ok(StaticDb.Notes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }
        [HttpGet("{index}")] //http://localhost:[port]/api/notes/1
        public ActionResult<Note> GetByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index can not be negative!");
                }
                if (index >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {index}");
                }

                return Ok(StaticDb.Notes[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }
        [HttpGet("queryString")]
        public ActionResult<Note> GetByQueryString(int? index)
        {
            try
            {
                if (index == null)
                {
                    return BadRequest("Index is a required parameter");
                }
                if (index < 0)
                {
                    return BadRequest();
                }
                if (index >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {index}");
                }
                return Ok(StaticDb.Notes[index.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred! Contact the admin!");
            }
        }
    }
}
