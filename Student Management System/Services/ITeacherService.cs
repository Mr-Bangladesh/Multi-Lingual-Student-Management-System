using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public interface ITeacherService
    {
        Task CreateTeacherAsync(CreateTeacherViewModel viewModel);
        Task<List<TeacherViewModel>> GetAllTeacherAsync();
        Task<TeacherViewModel> GetTeacherByIdAsync(int? id);
    }
}