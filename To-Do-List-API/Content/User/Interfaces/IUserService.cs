using To_Do_List_API.Content.User.DTO;

namespace To_Do_List_API.Content.User.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        System.Threading.Tasks.Task AddUserAsync(UserDto userDto);
        System.Threading.Tasks.Task UpdateUserAsync(int id,UserDto userDto);
        System.Threading.Tasks.Task DeleteUserAsync(int id);

    }
}
