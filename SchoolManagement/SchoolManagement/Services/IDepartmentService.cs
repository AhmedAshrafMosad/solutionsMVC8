using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllDepartmentsAsync();
        Task<DepartmentViewModel> GetDepartmentByIdAsync(int id);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
        Task<bool> DepartmentExistsAsync(int id);
        Task<List<Course>> GetAllCoursesAsync();
        Task<List<Student>> GetAllStudentsAsync();
    }
}