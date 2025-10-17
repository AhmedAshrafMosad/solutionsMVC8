using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Services
{
    public interface IStudentService
    {
        Task<StudentListViewModel> GetStudentsAsync(int page = 1, string searchName = "", int? departmentId = null);
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<bool> StudentExistsAsync(int id);
        Task<List<Department>> GetDepartmentsAsync();
        Task<StudentCourseResultViewModel> GetStudentCourseResultAsync(int studentId, int courseId);
    }
}