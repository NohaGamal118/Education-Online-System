using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        [ForeignKey("Course")]
        public int? CrsId { get; set; }
        [ForeignKey("Trainee")]
        public int? TraineeId { get; set; }
        public Course Course { get; set; }
        public Trainee Trainee { get; set; }
    }
}
