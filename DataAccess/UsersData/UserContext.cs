using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

using scrubcardshopAPI.Models;
using scrubcardshopAPI.DataAccess;

namespace scrubcardshopAPI.DataAccess.UserData
{
    public class UserContext : IUserContext
    {
        private readonly IMongoDatabase _database;

        public UserContext (IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("scrubshopDB"));
            if (client != null)
            {
                _database = client.GetDatabase("scrubshopDB");
            }
        }

        public IMongoCollection<UserDTO> Users => _database.GetCollection<UserDTO>("Users");
    }
    

}