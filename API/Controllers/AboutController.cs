using CRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.DAL;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/about")]
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AboutController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<About>> Get()
        {
            var notes = await _db.About.ToListAsync();

            return Ok(notes);
        }
    }
}
