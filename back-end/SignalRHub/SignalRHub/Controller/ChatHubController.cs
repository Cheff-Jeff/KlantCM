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
        private readonly IRepo<List<string>, string> _ImageData;
        public ChatHubController(IHubContext<Chathub> hubContext, IRepo<List<string>, string> imageData)
        {
            _hubContext = hubContext;
            _ImageData = imageData;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string connectionid, int index)
        {
            List<string> path = _ImageData.get(connectionid);
            if (path[index] == null)
            {
                return BadRequest("images does not exist");
            }
            var imageData = System.IO.File.ReadAllBytes(path[index]);
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
                if (_ImageData.Exists(connectionid))
                {
                    List<string> lis = _ImageData.get(connectionid);
                    lis.Add(filePath);
                    _ImageData.Update(lis, connectionid);
                }
                else
                {
                    List<string> lis = new()
                    {
                        filePath
                    };
                    _ImageData.Add(lis, connectionid);
                }
            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> deleteimg(string connection)
        {
            if (!_ImageData.Exists(connection))
            {
                return BadRequest("no images found");
            }
            List<string> images = _ImageData.get(connection);

            foreach(string img in images)
            {
                System.IO.File.Delete(img);
            }

            _ImageData.remove(connection);

            return Ok();
        }

    }
}
