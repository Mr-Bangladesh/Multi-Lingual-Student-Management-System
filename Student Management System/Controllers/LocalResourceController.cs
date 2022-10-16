using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Services;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Controllers
{
    public class LocalResourceController : BaseController
    {
        private readonly ILocalResourceService _localResourceService = null;
        public LocalResourceController(ILocalResourceService localResourceService)
        {
            _localResourceService = localResourceService;
        }
        // GET: CourseModels
        public async Task<IActionResult> Index()
        {
            var viewModel = await _localResourceService.GetAllLocalResourceAsync();
            return View(viewModel);
        }

        //// GET: CourseModels/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var courseModel = await _context.Courses
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (courseModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(courseModel);
        //}

        // GET: CourseModels/Create
        public IActionResult Create(int? id)
        {
            if(id == null)
            {
                NotFound();
            }
            return View();
        }

        // POST: CourseModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, CreateLocalResourceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _localResourceService.CreateLocalResourceAsync(viewModel, id);
                return RedirectToAction("Edit", "Language", new { id = id });
            }
            return View(viewModel);
        }

        //// GET: CourseModels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var courseModel = await _context.Courses.FindAsync(id);
        //    if (courseModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(courseModel);
        //}

        //// POST: CourseModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Code")] CourseModel courseModel)
        //{
        //    if (id != courseModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(courseModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CourseModelExists(courseModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(courseModel);
        //}

        //// GET: CourseModels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var courseModel = await _context.Courses
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (courseModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(courseModel);
        //}

        //// POST: CourseModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var courseModel = await _context.Courses.FindAsync(id);
        //    _context.Courses.Remove(courseModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CourseModelExists(int id)
        //{
        //    return _context.Courses.Any(e => e.Id == id);
        //}
    }
}
