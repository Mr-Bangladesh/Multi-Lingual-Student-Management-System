using System.Collections.Generic;

namespace Student_Management_System.ViewModels
{
    public class TeacherViewModel
    {
        public TeacherViewModel()
        {
            LocalizedProperties = new List<LocalizedPropertyViewModel>();
            TakenCourses = new List<CourseViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public IList<CourseViewModel> TakenCourses { get; set; }
        public IList<LocalizedPropertyViewModel> LocalizedProperties { get; set; }
    }
}
