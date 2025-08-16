using College.Domain.Entities;

namespace College.Domain.Repositories.Abstract
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetGradeAsync();
        Task<Grade?> GetGradeByIdAsync(int id);
        Task SaveGradeAsync(Grade entity);
        Task DeleteGradeAsync(int id);
    }
}
