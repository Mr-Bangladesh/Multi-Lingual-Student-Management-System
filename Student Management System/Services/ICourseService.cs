using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Services
{
    public interface ICourseService
    {
        List<CourseViewModel> GetAllCourse();
        //Task<CourseViewModel> GetCourseByIdAsync(int id);
        Task CreateCourseAsync(CreateCourseViewModel viewModel);
    }
}