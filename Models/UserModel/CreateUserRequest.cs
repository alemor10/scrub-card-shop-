using System;
using System.Collections.Generic;

namespace scrubcardshopAPI.Models
{
    public class CreateUserRequest
    {   
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get;set;}
    }
}