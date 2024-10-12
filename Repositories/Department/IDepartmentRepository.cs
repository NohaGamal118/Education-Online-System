using MVCTask.Models;

namespace MVCTask.Repositories.Departmentt
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
        void Save();
    }
}
