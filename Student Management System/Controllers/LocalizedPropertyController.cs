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

namespace Student_Management_System.Controllers
{
    public class LocalizedPropertyController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public LocalizedPropertyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocalizedPropertyModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocalizedProperty.ToListAsync());
        }

        // GET: LocalizedPropertyModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizedPropertyModel = await _context.LocalizedProperty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizedPropertyModel == null)
            {
                return NotFound();
            }

            return View(localizedPropertyModel);
        }

        // GET: LocalizedPropertyModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalizedPropertyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntityName,EntityPropertyName,LocalValue,EntityId")] LocalizedPropertyDomain localizedPropertyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localizedPropertyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localizedPropertyModel);
        }

        // GET: LocalizedPropertyModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizedPropertyModel = await _context.LocalizedProperty.FindAsync(id);
            if (localizedPropertyModel == null)
            {
                return NotFound();
            }
            return View(localizedPropertyModel);
        }

        // POST: LocalizedPropertyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntityName,EntityPropertyName,LocalValue,EntityId")] LocalizedPropertyDomain localizedPropertyModel)
        {
            if (id != localizedPropertyModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localizedPropertyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizedPropertyModelExists(localizedPropertyModel.Id))
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
            return View(localizedPropertyModel);
        }

        // GET: LocalizedPropertyModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizedPropertyModel = await _context.LocalizedProperty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizedPropertyModel == null)
            {
                return NotFound();
            }

            return View(localizedPropertyModel);
        }

        // POST: LocalizedPropertyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localizedPropertyModel = await _context.LocalizedProperty.FindAsync(id);
            _context.LocalizedProperty.Remove(localizedPropertyModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizedPropertyModelExists(int id)
        {
            return _context.LocalizedProperty.Any(e => e.Id == id);
        }
    }
}
