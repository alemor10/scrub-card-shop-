using System;
using System.Collections.Generic;

namespace scrubcardshopAPI.DataAccess.CardsData
{
    public interface ICardContext
    {
        public List<CardDTO> CardList {get;}
    }
}