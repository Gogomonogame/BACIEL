using College.Domain.Entities;
using College.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace College.Domain.Repositories.EntityFramework
{
    public class EFAbsenceRepository : IAbsenceRepository
    {
        private readonly AppDbContext _context;

        public EFAbsenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Absence>> GetAbsenceAsync()
        {
            return await _context.Absences
                .Include(x => x.Subject)
                .Include(x => x.Student)
                .ToListAsync();
        }
        public async Task<Absence?> GetAbsenceByIdAsync(int id)
        {
            return await _context.Absences
                .Include(x => x.Subject)
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveAbsenceAsync(Absence entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAbsenceAsync(int id)
        {
            _context.Entry(new Absence() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
