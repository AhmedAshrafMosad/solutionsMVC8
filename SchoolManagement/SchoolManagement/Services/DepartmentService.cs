using Microsoft.EntityFrameworkCore;
using SchoolManagement.Interfaces;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentViewModel>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllWithDetailsAsync();

            return departments.Select(d => new DepartmentViewModel
            {
                Id = d.Id,
                Name = d.Name,
                MgrName = d.MgrName,
                Students = d.Students.Select(s => new StudentDropdownItem
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age
                }).ToList(),
                StudentCount = d.Students.Count,
                Teachers = d.Teachers.ToList(),
                Courses = d.Courses.ToList(),
                StudentsFull = d.Students.ToList(),
                DepartmentState = "Active", // Set appropriate value
                SecurityCase = "Secure" // Set appropriate value
            }).ToList();
        }

        public async Task<DepartmentViewModel> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdWithDetailsAsync(id);
            if (department == null) return null;

            return new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                MgrName = department.MgrName,
                Students = department.Students.Select(s => new StudentDropdownItem
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age
                }).ToList(),
                StudentCount = department.Students.Count,
                Teachers = department.Teachers.ToList(),
                Courses = department.Courses.ToList(),
                StudentsFull = department.Students.ToList(),
                DepartmentState = "Active", // Set appropriate value
                SecurityCase = "Secure" // Set appropriate value
            };
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            await _departmentRepository.AddAsync(department);
            await _departmentRepository.SaveAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _departmentRepository.Update(department);
            await _departmentRepository.SaveAsync();
            return department;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department != null)
            {
                _departmentRepository.Remove(department);
                await _departmentRepository.SaveAsync();
            }
        }

        public async Task<bool> DepartmentExistsAsync(int id)
        {
            return await _departmentRepository.ExistsAsync(d => d.Id == id);
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _departmentRepository.GetAllCoursesAsync();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _departmentRepository.GetAllStudentsAsync();
        }
    }
}