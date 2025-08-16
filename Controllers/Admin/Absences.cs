using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> AbsenceEdit(int id)
        {
            //В залежності від існування ід, ми або додаємо, або редагуємо
            Absence? entity = id == default ? new Absence() : await _dataManager.Absences.GetAbsenceByIdAsync(id);
            ViewBag.Students = await _dataManager.Students.GetStudentAsync();
            ViewBag.Subjects = await _dataManager.Subjects.GetSubjectAsync();
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> AbsenceEdit(Absence entity)
        {
            //В моделі є помилки - повертаємо на доопрацювання
            if (!ModelState.IsValid)
            {
                ViewBag.Students = await _dataManager.Students.GetStudentAsync();
                ViewBag.Subjects = await _dataManager.Subjects.GetSubjectAsync();
                return View(entity);
            }
            await _dataManager.Absences.SaveAbsenceAsync(entity);
            _logger.LogInformation($"Додана/Оновлена інформація про пропуск з ID: {entity.Id}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AbsenceDelete(int id)
        {
            //Перевірити чи немає залежностей
            await _dataManager.Absences.DeleteAbsenceAsync(id);
            _logger.LogInformation($"Видалена інформація про пропуск з ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
