
using AutoMapper;
using System;

using scrubcardshopAPI.DataAccess.CardsData;
using scrubcardshopAPI.Models;
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