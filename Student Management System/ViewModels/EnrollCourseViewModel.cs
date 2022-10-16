namespace Student_Management_System.ViewModels
{
    public class EnrollCourseViewModel
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public string CourseTeacher { get; set; }
        public bool IsSelected { get; set; }
    }
}
