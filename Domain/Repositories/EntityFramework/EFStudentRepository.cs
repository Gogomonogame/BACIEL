using College.Domain.Entities;
using College.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace College.Domain.Repositories.EntityFramework
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public EFStudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            return await _context.Students
                .Include(x => x.Group)
                .Include(x => x.Grades)
                .Include(x => x.Absences)
                .ToListAsync();
        }
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Include(x => x.Group)
                .Include(x => x.Grades)
                .Include(x => x.Absences)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveStudentAsync(Student entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudentAsync(int id)
        {
            _context.Entry(new Student() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
