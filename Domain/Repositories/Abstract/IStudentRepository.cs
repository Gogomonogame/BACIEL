using College.Domain.Entities;

namespace College.Domain.Repositories.Abstract
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task SaveStudentAsync(Student entity);
        Task DeleteStudentAsync(int id);
    }
}
