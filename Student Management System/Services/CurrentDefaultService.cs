using System.Linq;
using Student_Management_System.Data;
using Student_Management_System.Domains;
using Student_Management_System.Models;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public class CurrentDefaultService : ICurrentDefaultService
    {
        private readonly ApplicationDbContext _context;
        public CurrentDefaultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCurrentDefaultProperty(CurrentDefaultViewModel viewModel)
        {
            var currentLanguage = _context.CurrentDefault.FirstOrDefault(x => x.PropertyName == viewModel.PropertyName);
            if (currentLanguage == null)
            {
                var model = new CurrentDefaultDomain()
                {
                    PropertyId = viewModel.PropertyId,
                    PropertyName = viewModel.PropertyName
                };
                _context.CurrentDefault.Add(model);
                _context.SaveChanges();
            }
            else
            {
                currentLanguage.PropertyId = viewModel.PropertyId;

                _context.CurrentDefault.Update(currentLanguage);
                _context.SaveChanges();
            }
        }

        public int GetCurrentLanguageId()
        {
            var model = _context.CurrentDefault.FirstOrDefault(x => x.PropertyName == "Language");

            return model.PropertyId;
        }
    }
}
