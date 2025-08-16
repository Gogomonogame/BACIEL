using College.Domain;
using College.Domain.Entities;
using College.Infrastructure;
using College.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly DataManager _dataManager;
        public AbsenceController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index(string? student, string? subject, string? date, string? closed)
        {
            // Отримати дані
            IEnumerable<Absence> list = await _dataManager.Absences.GetAbsenceAsync();
            IEnumerable<AbsenceDTO> listDTO = HelperDTO.TransformAbsences(list);

            // Фільтрація
            if (!string.IsNullOrEmpty(student))
                listDTO = listDTO.Where(a => a.StudentFirstname + " " + a.StudentSecondname == student);

            if (!string.IsNullOrEmpty(subject))
                listDTO = listDTO.Where(a => a.SubjectName == subject);

            if (!string.IsNullOrEmpty(date))
                listDTO = listDTO.Where(a => a.Date?.ToString("yyyy-MM-dd") == date);

            if (!string.IsNullOrEmpty(closed))
            {
                bool isClosed = closed == "Закритий";
                listDTO = listDTO.Where(a => a.IsClosed == isClosed);
            }

            // ViewBag для селектів
            ViewBag.Students = listDTO.Select(a => a.StudentFirstname + " " + a.StudentSecondname).Distinct().ToList();
            ViewBag.Subjects = listDTO.Select(a => a.SubjectName).Distinct().ToList();
            ViewBag.Dates = listDTO.Where(a => a.Date.HasValue).Select(a => a.Date!.Value).Distinct().ToList();
            ViewBag.Closed = new List<string> { "Закритий", "Не закритий" };

            return View(listDTO);
        }
    }
}
