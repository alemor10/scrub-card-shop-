using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;


using scrubcardshopAPI.Models;
using scrubcardshopAPI.Models.CardModel;
using scrubcardshopAPI.DataAccess;
using scrubcardshopAPI.DataAccess.UserData;
using scrubcardshopAPI.DataAccess.CardsData;


namespace scrubcardshopAPI.Services.CardServices
{
    public class CardService : ICardService
    {
        private readonly ICardContext _context;
        private readonly IUserContext _usercontext;
        private readonly IMapper _mapper;


        public CardService(ICardContext context, IUserContext userContext,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _usercontext = userContext;
        }
       
       public async Task<List<Card>> GetCards ()
       {
           var Jsoncards =  _context.CardList;
           var cards = new List<Card>();
           await Task.Run (() => 
           {
               foreach(var card in cards)
                {
                 cards.Add(_mapper.Map<Card>(card));
                }
           });
           return cards;
       }
       
       public async Task<Card> GetCard(string name)
       {
           var Jsoncard = new CardDTO();
           await Task.Run (() => 
           {
                Jsoncard = _context.CardList.Find(_ => _.name == name);
           });
           return _mapper.Map<CardDTO,Card>(Jsoncard);
       }

       public async Task CreateDeckList(createCardListRequest userrequest)
       {
            if (userrequest.Username is null)
            {
                throw new ArgumentException("No user");
            }
            
            var dbUser = await _usercontext.Users.Find(user => user.Username == userrequest.Username && user.Email == userrequest.Email).FirstOrDefaultAsync();
            if (dbUser is null)
            {
                //throw new NotFoundItemException("User not found");
            }
       
       }

    }
    
}