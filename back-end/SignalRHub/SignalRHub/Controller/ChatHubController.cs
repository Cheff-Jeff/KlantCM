using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hubs;
using SignalRHub.Repo;

namespace SignalRHub.Controller
{
    [RequestFormLimits(ValueCountLimit = 9000)]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHubController : ControllerBase
    {

        private readonly IHubContext<Chathub> _hubContext;
        private readonly IRepo<string, string> _ImageData;
        public ChatHubController(IHubContext<Chathub> hubContext, IRepo<string, string> imageData)
        {
            _hubContext = hubContext;
            _ImageData = imageData;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string connectionid)
        {
            string path = _ImageData.get(connectionid);
            if (string.IsNullOrEmpty(path))
            {
                return BadRequest("images does not exist");
            }
            var imageData = System.IO.File.ReadAllBytes(path);
            System.IO.File.Delete(path);
            _ImageData.remove(connectionid);
            return File(imageData, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, string connectionid)
        {
            string folder = "Images";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (file.Length > 0)
            {
                string filePath = Path.Combine(folder, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                _ImageData.Add(filePath, connectionid);
            }
            return Ok();
        }

    }
}
