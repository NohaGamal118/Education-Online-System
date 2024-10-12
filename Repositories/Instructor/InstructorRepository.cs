using MVCTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCTask.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly MVCTaskContext _context;

        public InstructorRepository(MVCTaskContext context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return _context.Instructors.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public void Update(Instructor instructor)
        {
            var oldInstructor = _context.Instructors.FirstOrDefault(i => i.Id == instructor.Id);
            if (oldInstructor != null)
            {
                oldInstructor.Name = instructor.Name;
                oldInstructor.Address = instructor.Address;
                oldInstructor.Image = instructor.Image;
                oldInstructor.Salary = instructor.Salary;
                oldInstructor.DepartmentId = instructor.DepartmentId;
                oldInstructor.CrsId = instructor.CrsId;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
