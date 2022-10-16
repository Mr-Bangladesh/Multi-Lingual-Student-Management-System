using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Domains;
using Student_Management_System.Models;
using System.Linq;

namespace Student_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<StudentDomain> Students { get; set; }
        public DbSet<LanguageDomain> Languages { get; set; }
        public DbSet<TeacherDomain> Teachers { get; set; }
        public DbSet<CourseDomain> Courses { get; set; }
        public DbSet<LocalizedPropertyDomain> LocalizedProperty { get; set; }

        public DbSet<LocalResourceDomain> LocalResource { get; set; }
        public DbSet<CurrentDefaultDomain> CurrentDefault { get; set; }
    }

}

