using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.StaticFiles;
namespace CityInfo.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {

        private readonly FileExtensionContentTypeProvider _fileExtentionContentTypeProvider;

        public FilesController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider
        ){
            _fileExtentionContentTypeProvider = fileExtensionContentTypeProvider??throw new System.ArgumentNullException(
                nameof(fileExtensionContentTypeProvider)
            );
        }


        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId){

            var pathToFile ="download.pdf";

            if(!System.IO.File.Exists(pathToFile)){
                return NotFound();
            }

            if(!_fileExtentionContentTypeProvider.TryGetContentType(
                pathToFile,out var contentType
            )){
                contentType = "application/octet-stream";//default media type
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes,contentType,Path.GetFileName(pathToFile));
        }
    }
}