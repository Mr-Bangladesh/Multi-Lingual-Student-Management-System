using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public interface ICurrentDefaultService
    {
        void AddCurrentDefaultProperty(CurrentDefaultViewModel viewModel);
        int GetCurrentLanguageId();
    }
}