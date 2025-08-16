using College.Domain;
using College.Domain.Entities;
using College.Infrastructure;
using College.Models;
using Microsoft.AspNetCore.Mvc;


namespace College.Controllers
{
    public class GroupController : Controller
    {
        private readonly DataManager _dataManager;
        public GroupController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Group> list = await _dataManager.Groups.GetGroupAsync();
            IEnumerable<GroupDTO> listDTO = HelperDTO.TransformGroups(list);
            return View(listDTO);
        }
        public async Task<IActionResult> GroupShow(int id)
        {
            Group? entity = await _dataManager.Groups.GetGroupByIdAsync(id);
            if (entity is null)
                return NotFound();
            GroupDTO entityDTO = HelperDTO.TransformGroup(entity);
            return View(entityDTO);
        }
        
    }
}
