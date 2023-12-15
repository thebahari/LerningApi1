using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace LerningApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider fileExtension;
        public FilesController(FileExtensionContentTypeProvider fileExtension)
        {
            this.fileExtension = fileExtension;
        }
        [HttpGet]
        public ActionResult GetFile()
        {
            var path = "1.pdf";
            if(!System.IO.File.Exists(path))
            {
                return NotFound();
            }
            var bytes=System.IO.File.ReadAllBytes(path);
            if(!fileExtension.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return File(bytes,contentType,Path.GetFileName(path));
        }
    }
}
