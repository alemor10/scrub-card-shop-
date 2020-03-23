using System;
using System.Collections.Generic;

namespace scrubcardshopAPI.Models
{
    public class User 
    {
        public string Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get;set;}
        public ICollection<Card> Deck {get; set;}
        public ICollection<Card> CardsForSale {get; set;}
        
    }    
}