using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public double MinDegree { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Instructor> instructors { get; set; }
        public virtual List<CrsResult> CrsResults { get; set; }
    }
}
