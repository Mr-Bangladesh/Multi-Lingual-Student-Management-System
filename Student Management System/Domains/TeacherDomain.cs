using System.Collections.Generic;

namespace Student_Management_System.Domains
{
    public class TeacherDomain : BaseDomain
    {
        public TeacherDomain()
        {
            TakenCourses = new List<CourseDomain>();
        }
        public string Name { get; set; }
        public string Designation { get; set; }

        public IList<CourseDomain> TakenCourses { get; set; }
    }
}
