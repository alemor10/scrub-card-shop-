using System;
using System.Collections.Generic;
using System.Text;

namespace scrubcardshopAPI.Models.CardModel
{
    public class createCardListRequest
    {
        public string Username {get;set;}
        public string Email {get;set;}
        public string[] cardList {get;set;}
    }
}