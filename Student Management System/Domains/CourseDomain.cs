using System.Collections.Generic;

namespace Student_Management_System.Domains
{
    public class CourseDomain : BaseDomain
    {
        public CourseDomain()
        {
            Students = new List<StudentDomain>();
        }
        public string Title { get; set; }
        public string Code { get; set; }
        public TeacherDomain CourseTeacher { get; set; }
        public IList<StudentDomain> Students { get; set; }
    }
}
