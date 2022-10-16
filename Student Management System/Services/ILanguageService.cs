using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public interface ILanguageService
    {
        Task CreateLanguageAsync(LanguageViewModel viewModel);
        Task DeleteLanguageAsync(int? id);
        Task<List<LanguageViewModel>> GetAllLanguageAsync();
        Task<LanguageViewModel> GetLanguageByIdAsync(int? id);
        Task UpdateLanguageAsync(LanguageViewModel viewModel, int id);
    }
}