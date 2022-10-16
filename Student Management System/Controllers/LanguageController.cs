using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;
using Student_Management_System.Services;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Controllers
{
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _languageService;
        private readonly ILocalResourceService _localResourceService;

        public LanguageController(ILanguageService languageService, ILocalResourceService localResourceService)
        {
            _languageService = languageService;
            _localResourceService = localResourceService;
        }

        // GET: LanguageModels
        public async Task<IActionResult> Index()
        {
            var viewModel = await _languageService.GetAllLanguageAsync();
            return View(viewModel);
        }

        // GET: LanguageModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _languageService.GetLanguageByIdAsync(id);
            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: LanguageModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LanguageModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _languageService.CreateLanguageAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: LanguageModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await _languageService.GetLanguageByIdAsync(id);
            var localResource = await _localResourceService.GetLocalResourceByLanguageAsync(id);

            ViewBag.localResource = localResource;

            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: LanguageModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LanguageViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _languageService.UpdateLanguageAsync(viewModel, id);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: LanguageModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await _languageService.GetLanguageByIdAsync(id);
            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: LanguageModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _languageService.DeleteLanguageAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LanguageModelExists(int id)
        {
            var viewModel = await _languageService.GetLanguageByIdAsync(id);
            if(viewModel == null)
            {
                return false;
            }
            return true;
        }
    }
}
