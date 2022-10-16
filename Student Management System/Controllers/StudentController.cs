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
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly ILanguageService _languageService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, ILanguageService languageService, ICourseService courseService)
        {
            _studentService = studentService;
            _languageService = languageService;
            _courseService = courseService;
        }

        // GET: StudentModels
        public async Task<IActionResult> Index()
        {
            var viewModel = await _studentService.GetAllStudentAsync();
            return View(viewModel);
        }

        // GET: StudentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = await _studentService.GetStudentByIdAsync(id);
            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        //GET: StudentModels/Create
        public async Task<IActionResult> Create()
        {
            var languageModel = await _languageService.GetAllLanguageAsync();
            ViewBag.languageModel = new SelectList(languageModel, "Id", "Name");
            return View();
        }

        // POST: StudentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _studentService.CreateStudentAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> EnrollCourse(int id)
        {
            var model = _courseService.GetAllCourse();
            var viewModel = new List<EnrollCourseViewModel>();
            foreach (var course in model)
            {
                viewModel.Add(new EnrollCourseViewModel()
                {
                    CourseId = course.Id,
                    CourseTitle = course.Title,
                    CourseCode = course.Code,
                    CourseTeacher = course.CourseTeacher,
                    IsSelected = await _studentService.IsEnrolledAsync(id, course.Id)
                }) ;
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EnrollCourse(int id, List<EnrollCourseViewModel> viewModel)
        {
            await _studentService.EnrollCoursesToStudentAsync(id, viewModel);
            return RedirectToAction("Details", new {id = id});
        }

        //// GET: StudentModels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var viewModel = await _studentService.GetStudentByIdAsync(id);
        //    //var studentModel = await _context.Students.FindAsync(id);
        //    if (viewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(viewModel);
        //}

        //// POST: StudentModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Roll")] StudentViewModel viewModel)
        //{
        //    if (id != viewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        await _studentService.UpdateStudentAsync(viewModel);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(viewModel);
        //}

        // GET: StudentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await _studentService.GetStudentByIdAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: StudentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private async Task<bool> StudentModelExists(int id)
        //{
        //    var viewModel = await _studentService.GetStudentByIdAsync(id);
        //    if(viewModel == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
