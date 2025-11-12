using Microsoft.AspNetCore.Mvc;

namespace DownloadExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        // GET: api/<DownloadController>
        [HttpGet]
        public async Task<IActionResult> GetZipFile()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files/simplewebsite.zip");

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found!");

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            return File(stream, "application/octet-stream", "net8.0.zip");
        }

        [HttpGet]
        public IActionResult GetJsonFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/version-info.json");

            if (!System.IO.File.Exists(path))
                return NotFound("File not found!");

            var json = System.IO.File.ReadAllText(path);
            return Content(json, "application/json");
        }
    }
}
