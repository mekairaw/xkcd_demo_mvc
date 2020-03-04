using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XKCDTest.Service.Interfaces;

namespace XKCDTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComicService _comicService;

        public HomeController(IComicService comicService)
        {
            _comicService = comicService;
        }

        public async Task<IActionResult> Index()
        {
            var comic = await _comicService.GetComicOfDay();
            return View(comic);
        }
        [Route("comic/{id}")]
        public async Task<IActionResult> Index([FromRoute]int id)
        {
            var comic = await _comicService.GetCustomComic(id);
            return View(comic);
        }
    }
}
