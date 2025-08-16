using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> StudentEdit(int id)
        {
            //В залежності від існування ід, ми або додаємо, або редагуємо
            Student? entity = id == default ? new Student() : await _dataManager.Students.GetStudentByIdAsync(id);
            ViewBag.Groups = await _dataManager.Groups.GetGroupAsync();
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> StudentEdit(Student entity)
        {
            //В моделі є помилки - повертаємо на доопрацювання
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = await _dataManager.Groups.GetGroupAsync();
                return View(entity);
            }

            await _dataManager.Students.SaveStudentAsync(entity);
            _logger.LogInformation($"Додана/Оновлена інформація про студента з ID: {entity.Id}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> StudentDelete(int id)
        {
            //Перевірити чи немає залежностей
            await _dataManager.Students.DeleteStudentAsync(id);
            _logger.LogInformation($"Видалена інформація про студента з ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
