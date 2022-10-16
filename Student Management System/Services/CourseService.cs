using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Domains;
using Student_Management_System.Models;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITeacherService _teacherService;
        public CourseService(ApplicationDbContext context, ITeacherService teacherService)
        {
            _context = context;
            _teacherService = teacherService;
        }
        public List<CourseViewModel> GetAllCourse()
        {
            var model = _context.Courses.Select(x => new CourseViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Code = x.Code,
                CourseTeacher = x.CourseTeacher.Name
            }).ToList();

            return model;
        }
        //public async Task<CourseViewModel> GetCourseByIdAsync(int id)
        //{

        //}

        public async Task CreateCourseAsync(CreateCourseViewModel viewModel)
        {
            int id = Int32.Parse(viewModel.CourseTeacher);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            var model = new CourseDomain()
            {
                Title = viewModel.Title,
                Code = viewModel.Code,
                CourseTeacher = teacher
            };

            _context.Courses.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
