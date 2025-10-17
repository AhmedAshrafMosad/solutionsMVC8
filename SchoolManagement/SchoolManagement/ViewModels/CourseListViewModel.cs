using SchoolManagement.Models;

namespace SchoolManagement.ViewModels
{
    public class CourseListViewModel
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SearchName { get; set; }
        public int? FilterDepartmentId { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}