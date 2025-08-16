using College.Domain;
using College.Domain.Entities;
using College.Infrastructure;
using College.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataManager _dataManager;
        public StudentController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> list = await _dataManager.Students.GetStudentAsync();
            IEnumerable<StudentDTO> listDTO = HelperDTO.TransformStudents(list);
            return View(listDTO);
        }
        /*
        public async Task<IActionResult> StudentShow(int id)
        {
            Student? entity = await _dataManager.Students.GetStudentByIdAsync(id);
            if (entity is null)
                return NotFound();
            StudentDTO entityDTO = HelperDTO.TransformStudent(entity);
            return View(entityDTO);
        }*/
    }
}
