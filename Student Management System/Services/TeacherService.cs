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
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILocalizedPropertyService _localizedPropertyService;
        public TeacherService(ApplicationDbContext context, ILocalizedPropertyService localizedPropertyService)
        {
            _context = context;
            _localizedPropertyService = localizedPropertyService;
        }

        public async Task<List<TeacherViewModel>> GetAllTeacherAsync()
        {
            var model = await _context.Teachers.ToListAsync();

            var viewModel = new List<TeacherViewModel>();

            foreach(var teacher in model)
            {
                viewModel.Add(new TeacherViewModel()
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Designation = teacher.Designation
                });
            }
            return viewModel;
        }

        public async Task<TeacherViewModel> GetTeacherByIdAsync(int? id)
        {
            var model = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            var localizedProperty = _localizedPropertyService.GetLocalizedPropertyAsync("Teachers", model.Id);

            var viewModel = await _context.Teachers.Where(x => x.Id == id).Select(y => new TeacherViewModel()
            {
                Id = y.Id,
                Name = y.Name,
                Designation = y.Designation,
                TakenCourses = y.TakenCourses.Select(m => new CourseViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Code = m.Code
                }).ToList(),
                LocalizedProperties = localizedProperty.Select(m => new LocalizedPropertyViewModel()
                {
                    EntityName = m.EntityName,
                    EntityPropertyName = m.EntityPropertyName,
                    LocalValue = m.LocalValue,
                    Language = m.Language.Name
                }).ToList()
            }).FirstOrDefaultAsync();

            //foreach (var data in localizedProperty)
            //{
            //    viewModel.LocalizedProperties.Add(new LocalizedPropertyViewModel()
            //    {
            //        EntityName = data.EntityName,
            //        EntityPropertyName = data.EntityPropertyName,
            //        LocalValue = data.LocalValue,
            //        Language = data.LanguageId.Name
            //    });
            //}

            return viewModel;
        }
        public async Task CreateTeacherAsync(CreateTeacherViewModel viewModel)
        {
            var model = new TeacherDomain()
            {
                Name = viewModel.Name,
                Designation = viewModel.Designation
            };

            _context.Teachers.Add(model);
            await _context.SaveChangesAsync();

            int nameLanguageId = Int32.Parse(viewModel.NameLanguage);
            var language = await _context.Languages.FirstOrDefaultAsync(m => m.Id == nameLanguageId);
            await _localizedPropertyService.CreateLocalizedProperty("Teachers", "Name", viewModel.NameTranslation, language, model.Id);

            int designationLanguageId = Int32.Parse(viewModel.DesignationLanguage);
            language = await _context.Languages.FirstOrDefaultAsync(m => m.Id == designationLanguageId);
            await _localizedPropertyService.CreateLocalizedProperty("Teachers", "Designation", viewModel.DesignationTranslation, language, model.Id);
        }
    }
}
