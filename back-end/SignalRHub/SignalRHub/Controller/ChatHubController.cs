using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hubs;

namespace SignalRHub.Controller
{
    [RequestFormLimits(ValueCountLimit = 9000)]
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
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {

            var name = Request.Form["name"];
            var size = Request.Form["size"];
            var lastModified = Request.Form["lastModified"];
            var lastModifiedDate = Request.Form["lastModifiedDate"];

            var value1 = Request.Form["value1"];
            var value2 = Request.Form["value2"];
            var value3 = Request.Form["value3"];
            var value4 = Request.Form["value4"];

            string type = file.ContentType;
            string Name = (string)name;
            System.Console.WriteLine(Name);



            //check form data


            return Ok();
        }

    }
}
