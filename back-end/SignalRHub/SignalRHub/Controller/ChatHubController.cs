using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRHub.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHubController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Hello, World!");
        }
    }
}
