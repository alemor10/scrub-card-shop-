using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

using scrubcardshopAPI.Models;
namespace scrubcardshopAPI.DataAccess.UserData
{
    public interface IUserContext
    {
        IMongoCollection<UserDTO> Users {get;}
    
    }
}