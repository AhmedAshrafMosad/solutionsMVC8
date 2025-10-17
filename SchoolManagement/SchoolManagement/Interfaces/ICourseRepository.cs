using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetCourseWithDetailsAsync(int id);
        Task<IEnumerable<Course>> GetCoursesWithDepartmentAsync();
        Task<CourseListViewModel> GetPagedCoursesAsync(int page = 1, int pageSize = 10, string searchName = "", int? departmentId = null);
        Task<IEnumerable<Course>> GetCoursesByDepartmentAsync(int departmentId);
    }
}