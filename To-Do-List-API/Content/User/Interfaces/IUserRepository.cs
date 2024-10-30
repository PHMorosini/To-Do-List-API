namespace To_Do_List_API.Content.User.Interfaces
{
    public interface IUserRepository
    {
        Task<Entity.User> GetUserByIdAsync(int id);
        Task<IEnumerable<Entity.User>> GetAllUsersAsync();
        System.Threading.Tasks.Task AddAsync(Entity.User user);
        System.Threading.Tasks.Task UpdateAsync(Entity.User user);
        System.Threading.Tasks.Task DeleteAsync(int id);
    }
}
