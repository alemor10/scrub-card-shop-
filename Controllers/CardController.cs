using System.Collections.Generic;
using scrubcardshopAPI.Models;
using scrubcardshopAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace scrubcardshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController: ControllerBase
    {
        private readonly CardService _cardservice;
        public CardController (CardService cardService)
        {
            _cardservice = cardService;
        }

        //returns entire list of cards
        [HttpGet]
        public ActionResult <List<Card>> Get()
        {
            var cardlist = _cardservice.Get();
            return Ok(cardlist);

        }

        //returns Card by card title 
        [HttpGet("{cardname:length(24)}")]
        [Route("category/{cardname}")]
        public ActionResult <List<Card>> Get(string cardname)
        {
          
           
           var card = _cardservice.Get(cardname);
           if (cardname == null)
           {
               return NotFound();
           }
           return card;

        }
    }
}