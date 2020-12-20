using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        
        public JsonResult GetStudents()
        {
            var studenten = _context.Student;
            return new JsonResult(studenten);
        }
        
        public JsonResult GetStudent(int id)
        {
            var student = _context.Student.Find(id);
            return new JsonResult(student);
        }

        [HttpPost]
        public JsonResult AddStudent([FromForm] Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
            return new JsonResult(HttpStatusCode.OK);
        }

        [HttpPut("{id}")]
        public JsonResult EditStudent(int id, [FromForm] Student student)
        {
            if (id != student.Id) return new JsonResult(HttpStatusCode.BadRequest);
            
            _context.Student.Update(student);
            _context.SaveChanges();
            return new JsonResult(HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteStudent(int id)
        {
            if (!_context.Student.Any(s => s.Id == id)) return new JsonResult(HttpStatusCode.BadRequest);
            
            var student = _context.Student.Single(s => s.Id == id);
            _context.Student.Remove(student);
            _context.SaveChanges();
            return new JsonResult(HttpStatusCode.OK);
        }
    }
}