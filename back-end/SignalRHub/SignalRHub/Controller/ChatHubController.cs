using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hubs;

namespace SignalRHub.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHubController : ControllerBase
    {

        private readonly IHubContext<Chathub> _hubContext;

        public ChatHubController(IHubContext<Chathub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok("Hello, World!");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            var value1 = Request.Form["value1"];
            var value2 = Request.Form["value2"];

            //check form data


            return Ok();
        }

    }
}
