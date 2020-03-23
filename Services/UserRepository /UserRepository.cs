using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using AutoMapper;

using scrubcardshopAPI.DataAccess.UserData;
using scrubcardshopAPI.Models;
using scrubcardshopAPI.DataAccess;



namespace scrubcardshopAPI.Services.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;
        private readonly IMapper _mapper;
        public UserRepository (IUserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var dbUsers = await _context.Users.Find(_ => true).ToListAsync();
            var users = new List<User>();
            foreach (var user in dbUsers)
            {
                users.Add(_mapper.Map<User>(user));
            }

                return users;
        }
        public async Task<User> GetUser(string id)
        {
            var dbUsers = await _context.Users.Find(us => us.Id == id).ToListAsync();
            if (dbUsers.Count == 0)
            {
                //throw new NotFoundItemException("No user found");
            }

            return _mapper.Map<UserDTO, User>(dbUsers[0]);
        }
        public async Task<User> CreateUser(CreateUserRequest createRequest)
        {
            //createRequest.Password = Crypto.ComputeSha256Hash(createRequest.Password);
            var dbUsers = await _context.Users.Find(us => us.Email == createRequest.Email && us.Password == createRequest.Password).ToListAsync();
            if (dbUsers.Count > 0)
            {
                //throw new RequestedResourceHasConflictException("Create failed. Change email");
            }
            var dbUser = _mapper.Map<CreateUserRequest, UserDTO>(createRequest);
            await _context.Users.InsertOneAsync(dbUser);
                
            return _mapper.Map<User>(dbUser);
        }
        public async Task<User> UpdateUser(string id, CreateUserRequest updateRequest)
        {
            var dbUsers = await _context.Users.Find(p => p.Email == updateRequest.Email && p.Id != id).ToListAsync();
            if (dbUsers.Count > 0)
            {
                //throw new RequestedResourceHasConflictException("Change password");
            }
            dbUsers = _context.Users.Find(p => p.Id ==id).ToList();
            if (dbUsers.Count == 0)
            {
                //throw new NotFoundItemException("No user found");
            }
            var dbUser = dbUsers[0];
            
            _mapper.Map(updateRequest,dbUser);

            await _context.Users.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(id)), dbUser);

            return _mapper.Map<User>(dbUser);

        }
        public async Task RemoveUser(string id)
        {
            var dbUsers = await _context.Users.Find(p => p.Id == id).ToListAsync();
            if (dbUsers.Count == 0)
            {
                //throw new NotFoundItemException("User not found");
            }

            var dbUser = dbUsers[0];

            await _context.Users.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }


            

    }
}
