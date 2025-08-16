using College.Domain.Entities;

namespace College.Domain.Repositories.Abstract
{
    public interface IAbsenceRepository
    {
        Task<IEnumerable<Absence>> GetAbsenceAsync();
        Task<Absence?> GetAbsenceByIdAsync(int id);
        Task SaveAbsenceAsync(Absence entity);
        Task DeleteAbsenceAsync(int id);
    }
}
