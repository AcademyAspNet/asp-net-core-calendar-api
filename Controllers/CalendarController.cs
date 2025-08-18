using Microsoft.AspNetCore.Mvc;

namespace MiddlewareExampleWebAPI.Controllers
{
    [ApiController]
    [Route("/calendar")]
    public class CalendarController : ControllerBase
    {
        [HttpGet("date")]
        public IActionResult GetCurrentDate()
        {
            string currentDate = DateTime.Now.ToShortDateString();
            return Content(currentDate);
        }

        [HttpGet("time")]
        public IActionResult GetCurrentTime()
        {
            string currentTime = DateTime.Now.ToShortTimeString();
            return Content(currentTime);
        }
    }
}
