using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace NZwalks.API.Controllers{

    // http://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: http://localhost:portnumber/api/students
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> GetAllStudents()
        {
            string[] studentsNames = new string[]
            {
                "John Doe",
                "Jane Smith",
                "Michael Johnson",
                "Emily Davis"
            };

            return Ok(studentsNames);
        }
    }
}


