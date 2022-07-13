using DotNetPractice.Models;
using DotNetPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetPractice.Razor.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentsService.GetAll();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await _studentsService.GetById(id);

            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreate student)
        {
            await _studentsService.Add(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentsService.GetById(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Student student)
        {
            await _studentsService.Update(id, student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentsService.GetById(id);

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            await _studentsService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
