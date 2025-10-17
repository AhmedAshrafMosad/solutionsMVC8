using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Interfaces;
using SchoolManagement.Models;

namespace SchoolManagement.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly SchoolContext _context;

        public DepartmentRepository(SchoolContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllWithDetailsAsync()
        {
            return await _context.Departments
                .Include(d => d.Students)
                .Include(d => d.Teachers)
                .Include(d => d.Courses)
                .ToListAsync();
        }

        public async Task<Department> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Departments
                .Include(d => d.Students)
                .Include(d => d.Teachers)
                .Include(d => d.Courses)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}