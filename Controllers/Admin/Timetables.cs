using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers.Admin
{
    public partial class AdminController
    {// ДОРОЛБИТИ СТОРІНКИ
        public async Task<IActionResult> TimetableEdit(int id)
        {
            //В залежності від існування ід, ми або додаємо, або редагуємо
            Timetable? entity = id == default ? new Timetable() : await _dataManager.Timetables.GetTimetableByIdAsync(id);

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> TimetableEdit(Timetable entity, IFormFile? scheduleImg, IFormFile? changesImg)
        {
            //В моделі є помилки - повертаємо на доопрацювання
            if (!ModelState.IsValid)
                return View(entity);
            if (scheduleImg == null && changesImg == null)
            {
                return View(entity);
            }
            if (scheduleImg != null)
            {
                entity.Schedule = scheduleImg.FileName;
                await SaveImg(scheduleImg);
            }    
            if(changesImg != null)
            {
                entity.Changes = changesImg.FileName;
                await SaveImg(changesImg);
            }    
            
            await _dataManager.Timetables.SaveTimetableAsync(entity);
            _logger.LogInformation($"Додана/Оновлена інформація про розклад/заміни з ID: {entity.Id}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> TimetableDelete(int id)
        {
            //Перевірити чи немає залежностей
            await _dataManager.Timetables.DeleteTimetableAsync(id);
            _logger.LogInformation($"Видалена інформація про розклад/заміни з ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
