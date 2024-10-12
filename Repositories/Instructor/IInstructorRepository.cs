using Microsoft.EntityFrameworkCore;
using MVCTask.Models;
using System.Collections.Generic;

namespace MVCTask.Repositories
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetAll();
        Instructor GetById(int id);
        void Add(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(int id);
        IEnumerable<Department> GetDepartments();
        IEnumerable<Course> GetCourses();
    }
}
