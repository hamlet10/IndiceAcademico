
using System.Linq;
using IndiceAcademico.Models;
using IndiceAcademico.Persistense;
using Microsoft.AspNetCore.Mvc;

namespace IndiceAcademico.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly AcademicDBContext _context;
        public EnrollmentsController(AcademicDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var enrollment = new Enrollments();
            ViewBag.students = _context.Students.ToList();
            ViewBag.subject = _context.Subjects.ToList();
            return View(enrollment);
        }
        [HttpPost]
        public IActionResult Index(Enrollments enrollments)
        {
            _context.Enrollments.Add(enrollments);
            _context.SaveChanges();
            return View();
        }
    }
}