using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Content.User.Entity;
using To_Do_List_API.Content.Task.Entity;
using To_Do_List_API.Content.Task.Enum;

namespace To_Do_List_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Content.Task.Entity.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content.Task.Entity.Task>()
                .Property(t => t.Status)
                .HasDefaultValue(StatusEnum.Ativa);

        }
    }

}
