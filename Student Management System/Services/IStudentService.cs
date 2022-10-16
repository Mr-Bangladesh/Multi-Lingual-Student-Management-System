using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public interface IStudentService
    {
        //Task<CreateStudentViewModel> CreateStudentAsync();
        Task CreateStudentAsync(CreateStudentViewModel viewModel);
        Task<List<StudentViewModel>> GetAllStudentAsync();
        Task<StudentViewModel> GetStudentByIdAsync(int? id);
        Task UpdateStudentAsync(StudentViewModel viewModel);
        Task DeleteStudentAsync(int id);
        Task EnrollCoursesToStudentAsync(int studentId, List<EnrollCourseViewModel> viewModel);
        Task<bool> IsEnrolledAsync(int studentId, int courseId);
        Task RemoveEnrolledCourses(int studentId);
    }
}