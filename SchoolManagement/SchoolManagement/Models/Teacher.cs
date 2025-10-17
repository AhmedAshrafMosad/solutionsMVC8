using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Salary { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(20)]
        public string CoursId { get; set; }

        public int DepartmentId { get; set; }

        // Navigation properties
        public Department Department { get; set; }
    }
}