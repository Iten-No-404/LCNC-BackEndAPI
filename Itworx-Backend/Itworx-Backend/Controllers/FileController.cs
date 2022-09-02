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
                string path = "";
                Console.WriteLine("################File Path:"+ file.ImagePath);
                Console.WriteLine("################File Name:" + file.ImageName);
                if (file.ImagePath != "")
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", file.ImagePath);
                    try
                    {
                        // Determine whether the directory exists.
                        if (Directory.Exists(path))
                        {
                            Console.WriteLine("That path exists already.");
                        }
                        else
                        {

                        // Try to create the directory.
                        DirectoryInfo di = Directory.CreateDirectory(path);
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                        }
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", file.ImagePath, file.ImageName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                }
                else
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.ImageName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.Image.CopyTo(stream);
                }
                if (file.ImagePath != "")
                    file.ImagePath = "localhost:5053/images/" + file.ImagePath + file.ImageName;
                else
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
