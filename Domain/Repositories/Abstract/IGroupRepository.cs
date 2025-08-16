using College.Domain.Entities;

namespace College.Domain.Repositories.Abstract
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetGroupAsync();
        Task<Group?> GetGroupByIdAsync(int id);
        Task SaveGroupAsync(Group entity);
        Task DeleteGroupAsync(int id);
    }
}
