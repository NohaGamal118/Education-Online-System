using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using MVCTask.Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MVCTask.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public IActionResult Index()
        {
            var instructors = _instructorRepository.GetAll();
            return View(instructors);
        }

        public IActionResult Detail(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Depts = _instructorRepository.GetDepartments();
            ViewBag.Courses = _instructorRepository.GetCourses();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Add(instructor);
                return RedirectToAction("Index");
            }
            ViewBag.Depts = _instructorRepository.GetDepartments();
            ViewBag.Courses = _instructorRepository.GetCourses();
            return View(instructor); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            ViewBag.Depts = _instructorRepository.GetDepartments();
            ViewBag.Courses = _instructorRepository.GetCourses();
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Instructor newInstructor, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    newInstructor.Image = fileName; 
                }

                _instructorRepository.Update(newInstructor);
                return RedirectToAction("Index");
            }
            ViewBag.Depts = _instructorRepository.GetDepartments();
            ViewBag.Courses = _instructorRepository.GetCourses();
            return View(newInstructor); 
        }
    }
}
