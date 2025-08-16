using College.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public partial class AdminController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<AdminController> _logger;
        public AdminController(DataManager dataManager, IWebHostEnvironment hostEnvironment, ILogger<AdminController> logger)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Groups = await _dataManager.Groups.GetGroupAsync();
            ViewBag.Students = await _dataManager.Students.GetStudentAsync();
            ViewBag.Grades = await _dataManager.Grades.GetGradeAsync();
            ViewBag.Absences = await _dataManager.Absences.GetAbsenceAsync();
            ViewBag.Subjects = await _dataManager.Subjects.GetSubjectAsync();
            ViewBag.Timetables = await _dataManager.Timetables.GetTimetableAsync();
            return View();
        }

        //Збереження зображень у файлову систему
        public async Task<string> SaveImg(IFormFile img)
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, "img/", img.FileName);
            await using FileStream stream = new FileStream(path, FileMode.Create);
            await img.CopyToAsync(stream);

            return path;
        }
    }
}
