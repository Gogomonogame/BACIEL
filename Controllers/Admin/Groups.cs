using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> GroupEdit(int id)
        {
            //В залежності від існування ід, ми або додаємо, або редагуємо
            Group? entity = id == default ? new Group() : await _dataManager.Groups.GetGroupByIdAsync(id);

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> GroupEdit(Group entity)
        {
            //В моделі є помилки - повертаємо на доопрацювання
            if (!ModelState.IsValid)
                return View(entity);

            await _dataManager.Groups.SaveGroupAsync(entity);
            _logger.LogInformation($"Додана/Оновлена інформація про групу з ID: {entity.Id}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> GroupDelete(int id)
        {
            //Перевірити чи немає залежностей
            await _dataManager.Groups.DeleteGroupAsync(id);
            _logger.LogInformation($"Видалена інформація про групу з ID: {id}");
            return RedirectToAction("Index");
        }
    }
    

}
