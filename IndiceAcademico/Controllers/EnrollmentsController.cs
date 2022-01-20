
using System.Linq;
using IndiceAcademico.Models;
using IndiceAcademico.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndiceAcademico.Controllers
{
    [Authorize]
    public class EnrollmentsController : Controller
    {
        private readonly AcademicDBContext _context;
        public EnrollmentsController(AcademicDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int success = 0)
        {
            var enrollment = new Enrollments();

            ViewBag.students = _context.Students.ToList();
            ViewBag.subject = _context.Subjects.ToList();
            ViewBag.success = success;
            return View(enrollment);
        }
        [HttpPost]
        public IActionResult Index([Bind("SubjectId, StudentId")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollments);
                _context.SaveChanges();
                return RedirectToAction("Index", new { success = 1 });
            }

            return View(enrollments);
        }
        
        public IActionResult Qualify(int subjectId, int studentId, Score score)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.ID == subjectId);
            var student = _context.Students.FirstOrDefault(s => s.ID == studentId);
            Enrollments enrollments = new Enrollments { StudentId = studentId, SubjectId = subjectId, Score = score };
            _context.Enrollments.Update(enrollments);
            _context.SaveChanges();

            return View();
        }
    }
}