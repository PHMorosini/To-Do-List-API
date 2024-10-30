using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Content.Task.Interfaces;


namespace To_Do_List_API.Content.Task.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext _context;

        public TaskRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Entity.Task> GetByIdAsync(int id)
        {
            return await _context.Set<Entity.Task>().FindAsync(id);
        }

        public async Task<IEnumerable<Entity.Task>> GetAllTasksAsync()
        {
            return await _context.Set<Entity.Task>().ToListAsync();
        }

        public async System.Threading.Tasks.Task AddAsync(Entity.Task task)
        {
            await _context.Set<Entity.Task>().AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Entity.Task task)
        {
            _context.Set<Entity.Task>().Update(task);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.Set<Entity.Task>().Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
