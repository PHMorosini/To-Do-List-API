using AutoMapper;
using To_Do_List_API.Content.User.DTO;
using To_Do_List_API.Content.User.Entity;

namespace To_Do_List_API.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,User>();
            CreateMap<User, UserDto>();
        }

    }
}
