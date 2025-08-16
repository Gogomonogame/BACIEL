using College.Domain.Entities;
using College.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace College.Domain.Repositories.EntityFramework
{
    public class EFSubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public EFSubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetSubjectAsync()
        {
            return await _context.Subjects
                .Include(x => x.Grades)
                .Include(x => x.Absences)
                .ToListAsync();
        }
        public async Task<Subject?> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects
                .Include(x => x.Grades)
                .Include(x => x.Absences)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveSubjectAsync(Subject entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSubjectAsync(int id)
        {
            _context.Entry(new Subject() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
