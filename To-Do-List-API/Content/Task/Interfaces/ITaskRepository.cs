using Microsoft.EntityFrameworkCore;

namespace To_Do_List_API.Content.Task.Interfaces
{
    public interface ITaskRepository
    {
        Task<Entity.Task> GetByIdAsync(int id); 
        Task<IEnumerable<Entity.Task>> GetAllTasksAsync();
        System.Threading.Tasks.Task AddAsync(Entity.Task task);
        System.Threading.Tasks.Task UpdateAsync(Entity.Task task); 
        System.Threading.Tasks.Task DeleteAsync(int id);
        System.Threading.Tasks.Task<IEnumerable<Entity.Task>> GetAllTasksByUser(int id);
    }
}
