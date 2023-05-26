using CRM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CRM.Controllers
{

    [Authorize(Roles = "Admin")]
    public class WorkerController : Controller
    {
        DiaryApiStore diary = new DiaryApiStore();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var app = await diary.AllNotesAsync();
            return View(app);
        }
        
        [HttpGet]
        public async Task<IActionResult> Blog()
        {
            var app = await diary.AllBlog();
            return View(app);
        }
        
        [HttpGet]
        public async Task<IActionResult> Wedo()
        {
            var app = await diary.AllWedo();
            return View(app);
        }
        
        [HttpGet]
        public async Task<IActionResult> About()
        {
            var app = await diary.AllAbout();
            return View(app);
        }
    }
}
