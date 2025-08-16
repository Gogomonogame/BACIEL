using College.Domain.Entities;
using College.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace College.Domain.Repositories.EntityFramework
{
    public class EFGroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public EFGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetGroupAsync()
        {
            return await _context.Groups.Include(x => x.Students).ToListAsync();
        }
        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            return await _context.Groups.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveGroupAsync(Group entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteGroupAsync(int id)
        {
            _context.Entry(new Group() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
