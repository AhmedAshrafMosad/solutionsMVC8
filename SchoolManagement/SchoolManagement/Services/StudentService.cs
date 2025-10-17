using SchoolManagement.Interfaces;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StudentService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<StudentListViewModel> GetStudentsAsync(int page = 1, string searchName = "", int? departmentId = null)
        {
            return await _studentRepository.GetPagedStudentsAsync(page, 10, searchName, departmentId);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentWithDetailsAsync(id);
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveAsync(); // استخدام SaveAsync
            return student;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            _studentRepository.Update(student);
            await _studentRepository.SaveAsync(); // استخدام SaveAsync
            return student;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                _studentRepository.Remove(student);
                await _studentRepository.SaveAsync(); // استخدام SaveAsync
            }
        }

        public async Task<bool> StudentExistsAsync(int id)
        {
            return await _studentRepository.ExistsAsync(s => s.Id == id);
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments.ToList();
        }

        public async Task<StudentCourseResultViewModel> GetStudentCourseResultAsync(int studentId, int courseId)
        {
            return await _studentRepository.GetStudentCourseResultAsync(studentId, courseId);
        }
    }
}