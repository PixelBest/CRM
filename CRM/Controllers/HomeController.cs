using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRM.Data;
using Test.Data;
using Microsoft.AspNetCore.Authorization;
using Test.DAL;
using Test.Models;
using a = CRM.Models;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /*IDiary diaryDataApi = new DiaryApiStore();*/
        DiaryApiStore diary = new DiaryApiStore();
        ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var a =  await diaryDataApi.AllNotes();
            return View();
        }

        public IActionResult Notice() => View();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreateUser() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUser(Notes model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model.Id = context.Notes.Count() + 1;
            model.Iban = "Ожидание";
            context.Notes.Add(model);
            await context.SaveChangesAsync();
            return RedirectToAction("notice", "Home");
        }

        public async Task<IActionResult> Service()
        {
            var a = await diary.AllAbout();
            return View(a);
        }

        public async Task<IActionResult> Project()
        {
            var a = await diary.AllWedo();
            return View(a);
        }

        public async Task<IActionResult> Blog()
        {
            var a = await diary.AllBlog();
            return View(a);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new a.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}