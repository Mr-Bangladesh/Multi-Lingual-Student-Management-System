using System.Collections.Generic;

namespace Student_Management_System.Domains
{
    public class StudentDomain : BaseDomain
    {
        public string Name { get; set; }
        public string Roll { get; set; }
        public IList<CourseDomain> EnrolledCourses { get; set; }
    }
}
