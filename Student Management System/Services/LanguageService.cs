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
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _context;

        public LanguageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageViewModel>> GetAllLanguageAsync()
        {
            var model = await _context.Languages.ToListAsync();

            List<LanguageViewModel> viewModel = new List<LanguageViewModel>();

            foreach (var language in model)
            {
                viewModel.Add(new LanguageViewModel()
                {
                    Id = language.Id,
                    Name = language.Name
                });
            }

            return viewModel;
        }

        public async Task<LanguageViewModel> GetLanguageByIdAsync(int? id)
        {
            var model = _context.Languages.Where(x => x.Id == id).Select(y => new LanguageViewModel()
            {
                Id = y.Id,
                Name = y.Name,
                LocalizedProperty = y.LocalizedProperty.Select(m => new LocalizedPropertyViewModel()
                {
                    EntityName = m.EntityName,
                    EntityPropertyName = m.EntityPropertyName,
                    LocalValue = m.LocalValue,
                    Language = m.Language.Name

                }).ToList()
            }).FirstOrDefault();
            return model;
        }

        public async Task CreateLanguageAsync(LanguageViewModel viewModel)
        {
            var model = new LanguageDomain()
            {
                Name = viewModel.Name
            };
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLanguageAsync(LanguageViewModel viewModel,int id)
        {
            var model = await _context.Languages.FirstOrDefaultAsync(x => x.Id == id);

            model.Name = viewModel.Name;

            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLanguageAsync(int? id)
        {
            var model = await _context.Languages.FindAsync(id);
            _context.Languages.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
