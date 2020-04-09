using System.Collections.Generic;
using System.Threading.Tasks;

using scrubcardshopAPI.Models;

namespace scrubcardshopAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string request);
        Task<User> CreateUser(CreateUserRequest user);
        Task<User> UpdateUser(string id, CreateUserRequest user);
        Task RemoveUser (string id);
    }
}