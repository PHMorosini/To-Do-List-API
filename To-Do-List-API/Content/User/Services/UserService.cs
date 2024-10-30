using AutoMapper;
using To_Do_List_API.Content.User.DTO;
using To_Do_List_API.Content.User.Interfaces;
using To_Do_List_API.Content.User.Repository;

namespace To_Do_List_API.Content.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task AddUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<Entity.User>(userDto);
           await _userRepository.AddAsync(user);
        }

        public async System.Threading.Tasks.Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = _userRepository.GetUserByIdAsync(id);
            if (user == null) throw new Exception("Usuario não encontrado");
            return _mapper.Map<UserDto>(user);

        }

        public async System.Threading.Tasks.Task UpdateUserAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) throw new Exception("Usuario não encontrado");
            
            user.Name = userDto.Name;
            user.Email = userDto.Email;

            await _userRepository.UpdateAsync(user);
        }
    }
}
