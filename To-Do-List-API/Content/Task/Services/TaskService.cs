using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using To_Do_List_API.Content.Task.DTO;
using To_Do_List_API.Content.Task.Interfaces;
using To_Do_List_API.Context;

namespace To_Do_List_API.Content.Task.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null) throw new Exception("Tarefa não encontrada");

            return _mapper.Map<TaskDto>(task);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async System.Threading.Tasks.Task AddTaskAsync(TaskDto taskDto)
        {
            var task = _mapper.Map<Entity.Task>(taskDto);
            task.CreatedAt = DateTime.Now; // Define a data de criação

            await _taskRepository.AddAsync(task);
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(int id, TaskDto taskDto)
        {
            var existingTask = await _taskRepository.GetByIdAsync(id);
            if (existingTask == null) throw new Exception("Tarefa não encontrada");

            existingTask.Name = taskDto.Name;
            existingTask.Description = taskDto.Description;
            existingTask.Status = taskDto.Status;

            await _taskRepository.UpdateAsync(existingTask);
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }



    }
}
