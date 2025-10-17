using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Degree is required")]
        [StringLength(50, ErrorMessage = "Degree cannot exceed 50 characters")]
        [Display(Name = "Degree Level")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Manager name is required")]
        [StringLength(100, ErrorMessage = "Manager name cannot exceed 100 characters")]
        [Display(Name = "Manager Name")]
        public string MgrName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<StuCrsRes> StuCrsRes { get; set; } = new List<StuCrsRes>();
    }
}