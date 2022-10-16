using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Domains;
using Student_Management_System.Models;
using Student_Management_System.Services;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Controllers
{
    public class TeacherController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILanguageService _languageService;
        private readonly ITeacherService _teacherService;

        public TeacherController(ApplicationDbContext context, ILanguageService languageService, ITeacherService teacherService)
        {
            _context = context;
            _languageService = languageService;
            _teacherService = teacherService;
        }

        // GET: TeacherModels
        public async Task<IActionResult> Index()
        {
            var viewModel = await _teacherService.GetAllTeacherAsync();
            return View(viewModel);
        }

        // GET: TeacherModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await _teacherService.GetTeacherByIdAsync(id);
            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: TeacherModels/Create
        public async Task<IActionResult> Create()
        {
            var languages = await _languageService.GetAllLanguageAsync();
            ViewBag.languages = new SelectList(languages, "Id", "Name");
            return View();
        }

        // POST: TeacherModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTeacherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _teacherService.CreateTeacherAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: TeacherModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherModel = await _context.Teachers.FindAsync(id);
            if (teacherModel == null)
            {
                return NotFound();
            }
            return View(teacherModel);
        }

        // POST: TeacherModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Designation")] TeacherDomain teacherModel)
        {
            if (id != teacherModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherModelExists(teacherModel.Id))
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
            return View(teacherModel);
        }

        // GET: TeacherModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherModel = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherModel == null)
            {
                return NotFound();
            }

            return View(teacherModel);
        }

        // POST: TeacherModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherModel = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(teacherModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherModelExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
