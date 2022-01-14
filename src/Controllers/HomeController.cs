using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
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
