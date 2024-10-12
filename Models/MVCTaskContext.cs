using Microsoft.EntityFrameworkCore;

namespace MVCTask.Models
{
    public class MVCTaskContext : DbContext
    {
        public MVCTaskContext(DbContextOptions<MVCTaskContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

}
