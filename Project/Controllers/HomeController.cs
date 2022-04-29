using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public OkObjectResult Get()
        {
            return Ok("Base API is running");
        }
    }
}
