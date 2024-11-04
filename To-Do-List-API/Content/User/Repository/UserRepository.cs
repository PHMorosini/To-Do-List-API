using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Content.User.Interfaces;
using To_Do_List_API.Context;

namespace To_Do_List_API.Content.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Entity.User user)
        {
            await _context.Set<Entity.User>().AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.Set<Entity.User>().Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Entity.User>> GetAllUsersAsync()
        {
            return await _context.Set<Entity.User>().Include(c => c.Tasks).ToListAsync();
        }

        public async Task<Entity.User> GetUserByIdAsync(int id)
        {
            return await _context.Set<Entity.User>().Include(c => c.Tasks).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Entity.User user)
        {
            _context.Set<Entity.User>().Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
