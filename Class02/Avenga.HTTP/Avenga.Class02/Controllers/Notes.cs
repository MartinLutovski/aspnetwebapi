using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avenga.Class02.Controllers
{
    [Route("api/[controller]")] // http://localhost:[port]/api/notes
    [ApiController]
    public class Notes : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            //return StatusCode(StatusCodes.Status200OK, StaticDb.SimpleNotes); // One way
            return Ok(StaticDb.SimpleNotes); // Another way
        }
        [HttpGet("{index}")]
        public ActionResult<string> GetByIndex(int index) 
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index has negative value");
                }
                if (index >= StaticDb.SimpleNotes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no resource on index {index}");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDb.SimpleNotes[index]);
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. Contact the admin");
            }
        }

    }
}
