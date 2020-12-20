using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WPFW_week15.Data;
using WPFW_week15.Models;

namespace WPFW_week15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WPFW_week15Context _context;

        public HomeController(ILogger<HomeController> logger, WPFW_week15Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public ObjectResult GetStudents()
        {
            var studenten = _context.Student;
            return new ObjectResult(studenten);
        }
        
        public ObjectResult GetStudent(int id)
        {
            var student = _context.Student.Find(id); ;
            return new ObjectResult(student);
        }
    }
}