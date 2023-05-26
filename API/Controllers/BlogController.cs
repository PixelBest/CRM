using CRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.DAL;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlogController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Blog>> Get()
        {
            var notes = await _db.Blog.ToListAsync();

            return Ok(notes);
        }
    }
}
