using System.Collections.Generic;
using System.Linq;
using scrubcardshopAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace scrubcardshopAPI.Services
{
    public class UserService 
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("scrubshopDB"));
            var database = client.GetDatabase("scrubshopDB");
            _users = database.GetCollection<User>("Users");
            System.Diagnostics.Debug.WriteLine(_users);
        }

        public List<User> Get()
        {
            return _users.Find(todo => true).ToList();
        }

        public User Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User newUser)
        {
            _users.ReplaceOne(user => user.Id == id,newUser);
        }
        
        public void Delete(string id)
        {
            _users.DeleteOne(user => user.Id ==id);
        }
        public void Delete(User user)
        {
            _users.DeleteOne(user => user.Id ==user.Id);
        }

    }
}