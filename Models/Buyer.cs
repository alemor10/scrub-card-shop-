using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace scrubcardshopAPI.Models
{
    public class Buyer : BaseUser 
    {
        [BsonElement]
        public string Name {get; set;}

        [BsonElement]
        public ICollection<Card> CardsForSale {get; set;}


    }
}