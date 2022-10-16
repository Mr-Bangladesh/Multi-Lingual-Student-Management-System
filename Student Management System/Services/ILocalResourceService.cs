using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public interface ILocalResourceService
    {
        Task<List<LocalResourceViewModel>> GetAllLocalResourceAsync();
        Task<List<LocalResourceViewModel>> GetLocalResourceByLanguageAsync(int? id);
        string GetLocalResourceByName(string resourceName);
        Task CreateLocalResourceAsync(CreateLocalResourceViewModel viewModel, int? languageId);
        Task LoadLocalResourceAsync(int? id);
    }
}