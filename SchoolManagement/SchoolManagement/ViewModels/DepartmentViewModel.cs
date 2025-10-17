using SchoolManagement.Models;

namespace SchoolManagement.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MgrName { get; set; } = string.Empty;
        public List<StudentDropdownItem> Students { get; set; } = new List<StudentDropdownItem>();
        public int StudentCount { get; set; }
        public string DepartmentState { get; set; } = string.Empty;
        public string SecurityCase { get; set; } = string.Empty;

        // Add navigation properties that your views expect
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Student> StudentsFull { get; set; } = new List<Student>();

        // Add properties for statistics that your views might be using
        public int TeachersCount => Teachers?.Count ?? 0;
        public int CoursesCount => Courses?.Count ?? 0;
        public int StudentsFullCount => StudentsFull?.Count ?? 0;
    }

    public class StudentDropdownItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}