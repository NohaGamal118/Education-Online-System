using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using MVCTask.Repositories.Departmentt;
using MVCTask.Repositories.Trainees;

namespace MVCTask.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public TraineeController(ITraineeRepository traineeRepository, IDepartmentRepository departmentRepository)
        {
            _traineeRepository = traineeRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var trainees = _traineeRepository.GetAll();
            return View(trainees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var depts = _departmentRepository.GetAll();
            ViewBag.depts = depts;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Trainee trainee)
        {
            if (trainee.Name != null)
            {
                _traineeRepository.Add(trainee);
                _traineeRepository.Save();
                return RedirectToAction("Index");
            }

            var depts = _departmentRepository.GetAll();
            ViewBag.depts = depts;
            return View("Add", trainee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var trainee = _traineeRepository.GetById(id);
            if (trainee == null)
            {
                return RedirectToAction("Index");
            }

            var depts = _departmentRepository.GetAll();
            ViewBag.Depts = depts;
            return View(trainee);
        }

        [HttpPost]
        public IActionResult Edit(int id, Trainee updatedTrainee, IFormFile ImageFile)
        {
            if (updatedTrainee.Name != null)
            {
                var existingTrainee = _traineeRepository.GetById(id);
                if (existingTrainee != null)
                {
                    existingTrainee.Name = updatedTrainee.Name;
                    existingTrainee.Address = updatedTrainee.Address;
                    existingTrainee.Grade = updatedTrainee.Grade;
                    existingTrainee.DepartmentId = updatedTrainee.DepartmentId;

                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(ImageFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            ImageFile.CopyTo(stream);
                        }
                        existingTrainee.Image = fileName;
                    }

                    _traineeRepository.Update(existingTrainee);
                    _traineeRepository.Save();
                    return RedirectToAction("Index");
                }
            }

            var depts = _departmentRepository.GetAll();
            ViewBag.Depts = depts;
            return View(updatedTrainee);
        }
    }
}