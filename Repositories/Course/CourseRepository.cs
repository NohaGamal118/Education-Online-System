using MVCTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCTask.Repositories.Coursee
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MVCTaskContext _context;

        public CourseRepository(MVCTaskContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }

        public void Delete(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
