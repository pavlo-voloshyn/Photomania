using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PVI.KR.DataAccess;
using PVI.KR.DataAccess.Entities;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace PVI.KR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private ImgDbContext _context;
        private UserManager<User> _userManager;

        public FileController(ImgDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles="Admin")]
        public IActionResult Upload()
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var tags = Request.Form["tags"].ToString();

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using var stream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(stream);

                var img = new Image
                {
                    Id = Guid.NewGuid(),
                    Src = dbPath,
                    InternalTags = tags,
                };

                _context.Images.Add(img);
                _context.SaveChanges();

                return Ok(new { src = dbPath, tags = img.Tags, id = img.Id });
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Images);
        }

        [HttpGet("favorite")]
        public IActionResult GetByUserId()
        {
            var id = Guid.Parse(User.FindFirstValue("id"));

            var res = _context.Images.Include(x => x.UserImages)
                .Where(x => x.UserImages.Any(x => x.Id == id))
                .ToList();

            return Ok(res.Select(x => new {x.Id, x.Src, x.Tags}));
        }

        [HttpPut("add-favorite")]
        public async Task<IActionResult> GetByUserId(Guid imgId)
        {
            var id = Guid.Parse(User.FindFirstValue("id"));
            var user = await _userManager.FindByIdAsync(id.ToString());

            var res = _context.Images.Include(x => x.UserImages)
                .First(x => x.Id == imgId);

            res.UserImages.Add(user);
            _context.SaveChanges();
            
            return Ok();
        }
    }
}
