using System.Collections.Generic;
using scrubcardshopAPI.Models;
using scrubcardshopAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace scrubcardshopAPI
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

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var cardlist = _cardservice.Get();
            return Ok(cardlist);

        }

        [HttpGet("{name:length(24)}", Name="GetCard")]
        public ActionResult <Card> Get(string name)
        {
            var card = _cardservice.Get(name);
            if(card == null)
            {
                return NotFound();
            }
            return card;
        }
    }
}