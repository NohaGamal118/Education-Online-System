using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("Course")]
        public int? CrsId { get; set; }
        public Department Department { get; set; }
        public Course Course { get; set; }
    }
}
