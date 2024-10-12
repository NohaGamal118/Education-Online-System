using MVCTask.Models;

namespace MVCTask.Repositories.Trainees
{
    public interface ITraineeRepository
    {
        IEnumerable<Trainee> GetAll();
        Trainee GetById(int id);
        void Add(Trainee trainee);
        void Update(Trainee trainee);
        void Save();
    }
}
