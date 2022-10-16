using System.Collections.Generic;

namespace Student_Management_System.ViewModels
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
            Students = new List<StudentViewModel>();
        }
        public int Id { get; set; }
        public string  Title { get; set; }
        public string Code { get; set; }
        public string CourseTeacher { get; set; }
        public IList<StudentViewModel> Students { get; set; }
    }
}
