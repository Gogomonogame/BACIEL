using College.Domain.Entities;

namespace College.Domain.Repositories.Abstract
{
    public interface ITimetableRepository
    {
        Task<IEnumerable<Timetable>> GetTimetableAsync();
        Task<Timetable?> GetTimetableByIdAsync(int id);
        Task SaveTimetableAsync(Timetable entity);
        Task DeleteTimetableAsync(int id);
    }
}
