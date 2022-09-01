using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IServices<ImageFile> _ImageService;
        public FileController(IServices<ImageFile> ImageService)
        {
            _ImageService = ImageService;
        }

        [HttpPost]
        public ActionResult Post([FromForm] ImageFile file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.ImageName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.Image.CopyTo(stream);
                }
                file.ImagePath = "localhost:5053/images/" + file.ImageName;
                _ImageService.Insert(file);
                return Ok(file);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
