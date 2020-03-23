using AutoMapper;

using scrubcardshopAPI.DataAccess;
using scrubcardshopAPI.Models;

namespace scrubcardshopAPI.Services.UserServices
{
    public class UserMapping :Profile
    {
        public UserMapping()
        {
            CreateMap<CreateUserRequest, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}