using College.Domain;
using College.Domain.Entities;
using College.Infrastructure;
using College.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class GradeController : Controller
    {
        private readonly DataManager _dataManager;
        public GradeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public async Task<IActionResult> Index(string? student, string? subject, DateTime? date)
        {
            IEnumerable<Grade> list = await _dataManager.Grades.GetGradeAsync();
            IEnumerable<GradeDTO> listDTO = HelperDTO.TransformGrades(list);

            // Унікальні значення для випадаючих списків
            ViewBag.Students = listDTO
                .Select(x => x.StudentFirstname + " " + x.StudentSecondname)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            ViewBag.Subjects = listDTO
                .Select(x => x.SubjectName)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            ViewBag.Dates = listDTO
                .Where(x => x.Date.HasValue)
                .Select(x => x.Date!.Value.Date)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            // Фільтрація
            if (!string.IsNullOrEmpty(student))
                listDTO = listDTO.Where(x => (x.StudentFirstname + " " + x.StudentSecondname) == student);

            if (!string.IsNullOrEmpty(subject))
                listDTO = listDTO.Where(x => x.SubjectName == subject);

            if (date.HasValue)
                listDTO = listDTO.Where(x => x.Date.HasValue && x.Date.Value.Date == date.Value.Date);

            return View(listDTO);
        }
        /*
        public async Task<IActionResult> GradesShow()
        {
            IEnumerable<Grade> list = await _dataManager.Grades.GetGradeAsync();
            IEnumerable<GradeDTO> listDTO = HelperDTO.TransformGrades(list);
            return View(listDTO);
        }*/
    }
}
