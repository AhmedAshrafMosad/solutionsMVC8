using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Models;
using SchoolManagement.Services;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // ✅ عرض جميع الأقسام مع بحث
        [HttpGet]
        public async Task<IActionResult> GetAll(string? searchName)
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();

            if (!string.IsNullOrEmpty(searchName))
            {
                departments = departments
                    .Where(d => d.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(departments);
        }

        // ✅ عرض تفاصيل قسم محدد - Uses ViewModel
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();

            return View(department);
        }

        // ✅ إنشاء قسم جديد - Uses Model (for form submission)
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Department());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Department department)
        {
            if (!ModelState.IsValid)
                return View(department);

            await _departmentService.CreateDepartmentAsync(department);
            TempData["Success"] = "Department added successfully!";
            return RedirectToAction(nameof(GetAll));
        }

        // ✅ تعديل قسم - Uses ViewModel for GET, Model for POST
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();

            // Convert DepartmentViewModel to Department model for the form
            var departmentModel = new Department
            {
                Id = department.Id,
                Name = department.Name,
                MgrName = department.MgrName
            };

            return View(departmentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department department)
        {
            if (!ModelState.IsValid)
                return View(department);

            await _departmentService.UpdateDepartmentAsync(department);
            TempData["Success"] = "Department updated successfully!";
            return RedirectToAction(nameof(GetAll));
        }

        // ✅ حذف قسم - Uses ViewModel
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            TempData["Success"] = "Department deleted successfully!";
            return RedirectToAction(nameof(GetAll));
        }
    }
}