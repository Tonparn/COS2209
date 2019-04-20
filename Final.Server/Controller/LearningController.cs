
using Final.Server.Common;
using Final.Server.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Final.Server.Controller
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LearningController : ControllerBase
    {
        private readonly ILearning _learningServices;

        public LearningController(ILearning learningServices)
        {
            _learningServices = learningServices;

        }

        [HttpPost("prepare-jupyter")]
        public IActionResult PrepareJupyter([FromBody] string name)
        {
            try
            {
                return Ok(_learningServices.PrepareJupyter(name));
            }
            catch(AvoidAuthLocal)
            {
                return StatusCode(423, "Locked");
            }
        }

        [HttpPost("prepare-lesson")]
        public async Task<IActionResult> PrepareLesson([FromBody] string lesson)
        {
            try
            {
                return Ok(await _learningServices.GetLesson(lesson));
            }
            catch(CourseNameException)
            {
                return BadRequest(Message.CourseNameNoteFound);
            }
        }
    }
}