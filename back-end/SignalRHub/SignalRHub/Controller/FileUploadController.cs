using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hubs;
using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace SignalRHub.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        private readonly IHubContext<Chathub> _hubContext;
        public FileUpload(IHubContext<Chathub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("files")]
        [HttpPost]
        public async Task UploadFile(IFormFile file)
        {

            if (ModelState.IsValid)
            {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);

                            var imageMessage = new ImageMessage
                            {
                                ImageHeaders = "data:" + file.ContentType + ";base64,",
                                ImageBinary = memoryStream.ToArray()
                            };

                            await _hubContext.Clients.All.SendAsync("ImageMessage", imageMessage);
                        }
                    }
            }
            

        }
    }
}
