using MVCTask.Models;
using System.Collections.Generic;

namespace MVCTask.Repositories.Coursee
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Add(Course course); 
        void Update(Course course);
        void Delete(Course course);
        public void Save();
    }
}
