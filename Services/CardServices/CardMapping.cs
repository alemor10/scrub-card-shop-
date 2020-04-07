using scrubcardshopAPI.DataAccess.CardsData;
using scrubcardshopAPI.Models.CardModel;
using scrubcardshopAPI.Models;
using AutoMapper;
using System;


namespace scrubcardshopAPI.Services.CardServices
{
    public class CardMapping : Profile
    {
        public CardMapping()
        {
            CreateMap<createCardListRequest,CardDTO>();
            CreateMap<CardDTO,Card>();

        }
    }
}