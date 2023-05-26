using CRM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.DAL;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/wedo")]
    public class WedoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WedoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Wedo>> Get()
        {
            var notes = await _db.Wedo.ToListAsync();

            return Ok(notes);
        }
    }
}
