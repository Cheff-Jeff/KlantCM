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
            if (file.Length > 0)
            {
                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return Ok();
        }

    }
}
