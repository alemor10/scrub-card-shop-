using System.Collections.Generic;
using scrubcardshopAPI.Models;
using scrubcardshopAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace scrubcardshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeckController: ControllerBase
    {
        private readonly CardService _cardservice;
        private readonly UserService _userservice;

        public DeckController (CardService cardService, UserService userService)
        {
            _cardservice = cardService;
            _userservice = userService;
        }

        //returns entire list of cards
        [HttpGet]
        public ActionResult <List<Card>> Get()
        {
            var cardlist = _cardservice.Get();
            return Ok(cardlist);

        }

        [HttpPut("{userid:length(24)}")]
        public IActionResult Update(string userid, User userIn)
        {
            User user = _userservice.Get(userid);
            return NoContent();
        }





        
    }

}

