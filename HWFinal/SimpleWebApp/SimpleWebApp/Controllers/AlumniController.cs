using Microsoft.AspNetCore.Mvc;

namespace SimpleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumniController : Controller 
    {
        [HttpGet("getallscores")]
        public ActionResult<IEnumerable<Alumni>> GetAll()
        {
            return new[]
            {
                new Alumni { Name = "Gabriel", Score = 95.6f },
                new Alumni { Name = "Felipe", Score = 80.5f },
                new Alumni { Name = "Emillia", Score = 74.8f }
            };
        }
    }
}
