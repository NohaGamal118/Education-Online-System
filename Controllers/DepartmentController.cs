using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using MVCTask.Repositories.Departmentt;

namespace MVCTask.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var depts = _departmentRepository.GetAll();
            return View(depts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (department.Name != null)
            {
                _departmentRepository.Add(department);
                _departmentRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Add", department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int id, Department updatedDepartment)
        {
            if (updatedDepartment.Name != null)
            {
                var existingDepartment = _departmentRepository.GetById(id);
                if (existingDepartment != null)
                {
                    existingDepartment.Name = updatedDepartment.Name;
                    existingDepartment.Manager = updatedDepartment.Manager;

                    _departmentRepository.Update(existingDepartment);
                    _departmentRepository.Save();
                    return RedirectToAction("Index");
                }
            }

            return View(updatedDepartment);
        }
    }
}