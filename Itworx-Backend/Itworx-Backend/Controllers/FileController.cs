using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Itworx_Backend.Domain.Entities;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromForm] ImageFile file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "..//..//..//", "CodedSummer2022_LCNC_T6_Frontend//itworx//public", file.ImageName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.Image.CopyTo(stream);
                }
                return Ok("../"+file.ImageName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
