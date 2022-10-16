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
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILanguageService _languageService;
        private readonly ILocalizedPropertyService _localizedPropertyService;

        public StudentService(ApplicationDbContext context, ILanguageService languageService, ILocalizedPropertyService localizedPropertyService)
        {
            _context = context;
            _languageService = languageService;
            _localizedPropertyService = localizedPropertyService;
        }

        public async Task<List<StudentViewModel>> GetAllStudentAsync()
        {
            var model = await _context.Students.ToListAsync();

            List<StudentViewModel> viewModel = new List<StudentViewModel>();

            foreach (var student in model)
            {
                viewModel.Add(new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Roll = student.Roll
                });
            }

            return viewModel;
        }

        public async Task<StudentViewModel> GetStudentByIdAsync(int? id)
        {
            var model = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            //var viewModel = new StudentViewModel()
            //{
            //    Id = model.Id,
            //    Name = model.Name,
            //    Roll = model.Roll,
            //};

            var viewModel = await _context.Students.Where(x => x.Id == id).Select(y => new StudentViewModel()
            {
                Id = y.Id,
                Name = y.Name,
                Roll = y.Roll,
                EnrolledCourses = y.EnrolledCourses.Select(m => new CourseViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Code = m.Code,
                    CourseTeacher = m.CourseTeacher.Name
                }).ToList()
            }).FirstOrDefaultAsync();

            var localizedProperty = _localizedPropertyService.GetLocalizedPropertyAsync("Students", model.Id);

            foreach(var data in localizedProperty)
            {
                viewModel.LocalizedProperties.Add(new LocalizedPropertyViewModel()
                {
                    EntityName = data.EntityName,
                    EntityPropertyName = data.EntityPropertyName,
                    LocalValue = data.LocalValue,
                    Language = data.Language.Name
                });
            }

            return viewModel;
        }

        public async Task CreateStudentAsync(CreateStudentViewModel viewModel)
        {
            var model = new StudentDomain()
            {
                Name = viewModel.Name,
                Roll = viewModel.Roll
            };
            _context.Students.Add(model);
            await _context.SaveChangesAsync();

            int id = Int32.Parse(viewModel.Language);

            var language = await _context.Languages.FirstOrDefaultAsync(m => m.Id == id);

            await _localizedPropertyService.CreateLocalizedProperty("Students","Name",viewModel.Translation,language,model.Id);
        }

        public async Task UpdateStudentAsync(StudentViewModel viewModel)
        {
            var model = new StudentDomain()
            {
                Name = viewModel.Name,
                Roll = viewModel.Roll
            };

            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var model = await _context.Students.FindAsync(id);
            _context.Students.Remove(model);
            await _context.SaveChangesAsync();

            await _localizedPropertyService.DeleteLocalizedPropertyAsync(id);
        }

        public async Task RemoveEnrolledCourses(int studentId)
        {
            //var student = await _context.Students.FindAsync(studentId);
            //student.EnrolledCourses.Remove();
            var student = await _context.Students.Where(x => x.Id == studentId).Select(y => new StudentDomain()
            {
                Id = y.Id,
                EnrolledCourses = y.EnrolledCourses.Select(z => new CourseDomain()
                {
                    Id = z.Id,
                    Title = z.Title,
                    Code = z.Code
                }).ToList()
            }).FirstOrDefaultAsync();

            student.EnrolledCourses.Clear();

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task EnrollCoursesToStudentAsync(int studentId, List<EnrollCourseViewModel> viewModel)
        {
            var student = await _context.Students.FindAsync(studentId);

            var courseIdList = viewModel.Where(y => y.IsSelected).Select(z => z.CourseId).ToList();
            var courses = _context.Courses.Where(x => courseIdList.Contains(x.Id)).ToList();

            //var courses = _context.Courses.Where(x => viewModel.Where(y => y.IsSelected).Select(z => z.CourseId).ToList().Contains(x.Id)).ToList();

            //await RemoveEnrolledCourses(studentId); //not working
            student.EnrolledCourses = courses;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEnrolledAsync(int studentId, int courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            var model = await _context.Students.Where(x => x.Id == studentId).Select(y => y.EnrolledCourses.Contains(course)).FirstOrDefaultAsync();

            return model;
        }
    }
}
