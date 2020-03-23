using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using scrubcardshopAPI.Models;


namespace scrubcardshopAPI.DataAccess
{
    public class UserDTO 
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Deck")]
        public ICollection<Card> Deck {get; set;}

        [BsonElement("CardsForSale")]
         public ICollection<Card> CardsForSale {get; set;}


    }
}