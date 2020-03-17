using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace scrubcardshopAPI.Models
{
    public class User :BaseUser
    {

        [BsonElement]
        public string Name {get; set;}

        [BsonElement]
        public ICollection<Card> Deck {get; set;}


        
    }
}