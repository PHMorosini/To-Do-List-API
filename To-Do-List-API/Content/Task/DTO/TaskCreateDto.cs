using To_Do_List_API.Content.Task.Enum;

namespace To_Do_List_API.Content.Task.DTO
{
    public class TaskCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public int UserId { get; set; }
    }
}
