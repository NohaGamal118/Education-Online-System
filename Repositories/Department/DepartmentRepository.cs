using MVCTask.Models;

namespace MVCTask.Repositories.Departmentt
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MVCTaskContext _context;

        public DepartmentRepository(MVCTaskContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
        }

        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

