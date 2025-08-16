using College.Domain.Entities;
using College.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace College.Domain.Repositories.EntityFramework
{
    public class EFTimetableRepository : ITimetableRepository
    {
        private readonly AppDbContext _context;

        public EFTimetableRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Timetable>> GetTimetableAsync()
        {
            return await _context.Timetables
                .ToListAsync();
        }
        public async Task<Timetable?> GetTimetableByIdAsync(int id)
        {
            return await _context.Timetables
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveTimetableAsync(Timetable entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTimetableAsync(int id)
        {
            _context.Entry(new Timetable() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
