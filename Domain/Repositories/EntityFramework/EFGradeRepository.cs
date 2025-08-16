using College.Domain.Entities;
using College.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace College.Domain.Repositories.EntityFramework
{
    public class EFGradeRepository : IGradeRepository
    {
        private readonly AppDbContext _context;

        public EFGradeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grade>> GetGradeAsync()
        {
            return await _context.Grades
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .ToListAsync();
        }
        public async Task<Grade?> GetGradeByIdAsync(int id)
        {
            return await _context.Grades
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveGradeAsync(Grade entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteGradeAsync(int id)
        {
            _context.Entry(new Grade() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
