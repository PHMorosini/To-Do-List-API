using AutoMapper;
using To_Do_List_API.Content.Task.DTO;
using To_Do_List_API.Content.Task.Entity;
using Task = To_Do_List_API.Content.Task.Entity.Task;

namespace To_Do_List_API.Mappers
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDto, Task>();
            CreateMap<Task, TaskDto>();
            CreateMap<TaskCreateDto, Task>();
        }
    }
}
