using To_Do_List_API.Content.Task.DTO;

namespace To_Do_List_API.Content.Task.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> GetTaskByIdAsync(int id); 
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        System.Threading.Tasks.Task AddTaskAsync(TaskDto taskDto);
        System.Threading.Tasks.Task UpdateTaskAsync(int id, TaskDto taskDto); 
        System.Threading.Tasks.Task DeleteTaskAsync(int id); 

    }
}
