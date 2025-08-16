using College.Domain;
using College.Domain.Entities;
using College.Infrastructure;
using College.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class TimetableController : Controller
    {
        private readonly DataManager _dataManager;
        public TimetableController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Timetable> list = await _dataManager.Timetables.GetTimetableAsync();
            IEnumerable<TimetableDTO> listDTO = HelperDTO.TransformTimetables(list);
            return View(listDTO);
        }
        public async Task<IActionResult> ScheduleShow()
        {
            IEnumerable<Timetable> list = await _dataManager.Timetables.GetTimetableAsync();
            IEnumerable<TimetableDTO> listDTO = HelperDTO.TransformTimetables(list);
            return View(listDTO);
        }
        public async Task<IActionResult> ChangesShow()
        {
            IEnumerable<Timetable> list = await _dataManager.Timetables.GetTimetableAsync();
            IEnumerable<TimetableDTO> listDTO = HelperDTO.TransformTimetables(list);
            return View(listDTO);
        }
    }
}
