using College.Domain;
using College.Domain.Entities;
using College.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace College.Models.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;
        public MenuViewComponent(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Group> listGroup = await _dataManager.Groups.GetGroupAsync();

            IEnumerable<GroupDTO> listGroupDTO = HelperDTO.TransformGroups(listGroup);

            return await Task.FromResult((IViewComponentResult)View("Default", listGroupDTO));
        }
    }
}
