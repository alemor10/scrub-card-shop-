using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;


using scrubcardshopAPI.Models;
using scrubcardshopAPI.DataAccess.UserData;
using scrubcardshopAPI.Services.UserRepository;
using scrubcardshopAPI.Services.UserServices;

namespace scrubcardshopAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService (IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetUsers();
        }


        public async Task<User> GetUser(string id)
        {
            return await _repository.GetUser(id);
        }

        public async Task<User> CreateUser(CreateUserRequest createRequest)
        {
            return await _repository.CreateUser(createRequest);
        }

        public async Task<User> UpdateUser(string id, CreateUserRequest updateRequest)
        {
            return await _repository.UpdateUser(id, updateRequest);
        }

        public async Task RemoveUser(string id)
        {
            await _repository.RemoveUser(id);
        }




    }
}