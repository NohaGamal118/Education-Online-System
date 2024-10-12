using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using MVCTask.Repositories.Coursee;
using MVCTask.Repositories.Departmentt;

namespace MVCTask.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var depts = _departmentRepository.GetAll();
            ViewBag.Depts = depts;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid) 
            {
                _courseRepository.Add(course);
                _courseRepository.Save();
                return RedirectToAction("Index");
            }
            var depts = _departmentRepository.GetAll();
            ViewBag.Depts = depts;
            return View(course); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return RedirectToAction("Index");
            }
            var depts = _departmentRepository.GetAll();
            ViewBag.Depts = depts;
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int id, Course updatedCourse)
        {
            if (ModelState.IsValid) 
            {
                var existingCourse = _courseRepository.GetById(id);
                if (existingCourse != null)
                {
                    existingCourse.Name = updatedCourse.Name;
                    existingCourse.Degree = updatedCourse.Degree;
                    existingCourse.MinDegree = updatedCourse.MinDegree;
                    existingCourse.DepartmentId = updatedCourse.DepartmentId;

                    _courseRepository.Update(existingCourse);
                    _courseRepository.Save();
                    return RedirectToAction("Index");
                }
            }

            var depts = _departmentRepository.GetAll();
            ViewBag.Depts = depts;
            return View(updatedCourse); 
        }
    }
}
