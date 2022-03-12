using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using QUIZ.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QUIZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QUIZContext _context;

        public HomeController(ILogger<HomeController> logger, QUIZContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Home()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View("Dashboard");
        }
        [HttpPost]
        public IActionResult Index(ExamSet examSet)
        {
            if(examSet.CategoryId == 1002)
            {
                var exam = _context.Questions.OrderBy(z => Guid.NewGuid()).Take(examSet.TotalQuestion);
                return View(exam);
            }
            else
            {
                var exam = _context.Questions.Where(x => x.CategoryId == examSet.CategoryId).OrderBy(z => Guid.NewGuid()).Take(examSet.TotalQuestion);
                return View(exam);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
