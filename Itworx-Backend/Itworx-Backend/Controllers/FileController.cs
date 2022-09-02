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

        /// <summary>
        /// Receive the Image File from the client side and store it in static folder (wwwroot) in images folder 
        /// and store the path to the image in the database and return the path to client side 
        /// </summary>
        /// <param name="file"> File which store image</param>
        /// <returns> path to the image  </returns>

        [HttpPost]
        public ActionResult PostImage([FromForm] ImageFile file)
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
