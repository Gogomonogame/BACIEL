using College.Domain.Entities;

namespace College.Domain.Repositories.Abstract
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjectAsync();
        Task<Subject?> GetSubjectByIdAsync(int id);
        Task SaveSubjectAsync(Subject entity);
        Task DeleteSubjectAsync(int id);
    }
}
