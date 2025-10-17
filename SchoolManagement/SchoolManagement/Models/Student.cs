using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(100)]
        [Display(Name = "اسم الطالب")]
        public string Name { get; set; }

        [Required(ErrorMessage = "العمر مطلوب")]
        [Range(18, 50, ErrorMessage = "العمر يجب أن يكون بين 18 و 50")]
        [Display(Name = "العمر")]
        public int Age { get; set; }

        [Required(ErrorMessage = "القسم مطلوب")]
        [Display(Name = "القسم")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
        public ICollection<StuCrsRes> StuCrsRes { get; set; } = new List<StuCrsRes>();
    }
}
