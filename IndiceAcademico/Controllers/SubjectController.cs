using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndiceAcademico.Models;
using IndiceAcademico.Persistence;
using Microsoft.AspNetCore.Identity;
using IndiceAcademico.Persistence.Identity;
using Microsoft.AspNetCore.Authorization;

namespace IndiceAcademico.Controllers
{
    [Authorize(Roles = "Professor")]
    public class SubjectController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AcademicDBContext _context;

        public SubjectController(AcademicDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            var subjects = await _context.Subjects.Where(s => s.ProfessorId == user.Id).ToListAsync();
            return View(subjects);
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subjectNme =  _context.Subjects.FirstOrDefault(s => s.ID == id);
            ViewBag.SubjectName = subjectNme.Name.ToString();

            var students = await _context.Enrollments.Where(s => s.SubjectId == id).Include(s => s.Student).ToListAsync();

            //var subject = await _context.Subjects
            //    .Include(s => s.Professor)
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (subject == null)
            //{
            //    return NotFound();
            //}

            return View(students);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "ID", "LastName");
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Name,Cred,ProfessorId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "ID", "LastName", subject.ProfessorId);
            return View(subject);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int? subjectId, int? studentId)
        {
            if (subjectId == null)
            {
                return NotFound();
            }


            var subject = await _context.Subjects.FindAsync(subjectId);
            
            if (subject == null)
            {
                return NotFound();
            }
            //ViewData["ProfessorId"] = new SelectList(_context.Professors, "ID", "LastName", subject.ProfessorId);
            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,Name,Cred,ProfessorId")] Subject subject)
        {
            if (id != subject.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professors, "ID", "LastName", subject.ProfessorId);
            return View(subject);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.Professor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.ID == id);
        }
    }
}
