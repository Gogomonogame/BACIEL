using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> GradeEdit(int id)
        {
            //В залежності від існування ід, ми або додаємо, або редагуємо
            Grade? entity = id == default ? new Grade() : await _dataManager.Grades.GetGradeByIdAsync(id);
            ViewBag.Students = await _dataManager.Students.GetStudentAsync();
            ViewBag.Subjects = await _dataManager.Subjects.GetSubjectAsync();
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> GradeEdit(Grade entity)
        {
            //В моделі є помилки - повертаємо на доопрацювання
            if (!ModelState.IsValid)
            {
                ViewBag.Students = await _dataManager.Students.GetStudentAsync();
                ViewBag.Subjects = await _dataManager.Subjects.GetSubjectAsync();
                return View(entity);
            }
                

            await _dataManager.Grades.SaveGradeAsync(entity);
            _logger.LogInformation($"Додана/Оновлена інформація про оцінку з ID: {entity.Id}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> GradeDelete(int id)
        {
            //Перевірити чи немає залежностей
            await _dataManager.Grades.DeleteGradeAsync(id);
            _logger.LogInformation($"Видалена інформація про оцінку з ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
