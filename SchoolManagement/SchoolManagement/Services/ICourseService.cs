using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Services
{
    public interface ICourseService
    {
        Task<CourseListViewModel> GetCoursesAsync(int page = 1, string searchName = "", int? departmentId = null);
        Task<Course> GetCourseByIdAsync(int id);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
        Task<bool> CourseExistsAsync(int id);
        Task<List<Department>> GetDepartmentsAsync();
        Task<List<Course>> GetAllCoursesAsync();
    }
}