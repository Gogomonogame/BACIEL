using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> SubjectEdit(int id)
        {
            //В залежності від існування ід, ми або додаємо, або редагуємо
            Subject? entity = id == default ? new Subject() : await _dataManager.Subjects.GetSubjectByIdAsync(id);

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> SubjectEdit(Subject entity)
        {
            //В моделі є помилки - повертаємо на доопрацювання
            if (!ModelState.IsValid)
                return View(entity);

            await _dataManager.Subjects.SaveSubjectAsync(entity);
            _logger.LogInformation($"Додана/Оновлена інформація про предмет з ID: {entity.Id}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SubjectDelete(int id)
        {
            //Перевірити чи немає залежностей
            await _dataManager.Subjects.DeleteSubjectAsync(id);
            _logger.LogInformation($"Видалена інформація про предмет з ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
