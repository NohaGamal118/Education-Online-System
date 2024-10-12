using MVCTask.Models;

namespace MVCTask.Repositories.Trainees
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly MVCTaskContext _context;

        public TraineeRepository(MVCTaskContext context)
        {
            _context = context;
        }

        public IEnumerable<Trainee> GetAll()
        {
            return _context.Trainees.ToList();
        }

        public Trainee GetById(int id)
        {
            return _context.Trainees.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Trainee trainee)
        {
            _context.Trainees.Add(trainee);
        }

        public void Update(Trainee trainee)
        {
            _context.Trainees.Update(trainee);
        }

        public void Delete(Trainee trainee)
        {
            _context.Trainees.Remove(trainee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

