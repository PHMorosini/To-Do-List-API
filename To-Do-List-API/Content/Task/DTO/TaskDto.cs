using To_Do_List_API.Content.Task.Enum;

namespace To_Do_List_API.Content.Task.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
