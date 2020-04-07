using System.Collections.Generic;
using scrubcardshopAPI.Models;
using scrubcardshopAPI.Services.CardServices;
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




    }
}