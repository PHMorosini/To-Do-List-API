using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Content.User.Entity;
using To_Do_List_API.Content.Task.Entity;

namespace To_Do_List_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Content.Task.Entity.Task> Tasks { get; set; }  // Exemplo com uma entidade Task
        public DbSet<User> Users { get; set; }
    }
}
