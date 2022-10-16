using System.Collections.Generic;

namespace Student_Management_System.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            LocalizedProperties = new List<LocalizedPropertyViewModel>();
            EnrolledCourses = new List<CourseViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }

        public IList<CourseViewModel> EnrolledCourses { get; set; }

        public IList<LocalizedPropertyViewModel> LocalizedProperties { get; set; }
    }
}
