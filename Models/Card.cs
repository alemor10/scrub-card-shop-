using System.Collections.Generic;

namespace scrubcardshopAPI.Models
{
    public class Card : BaseCard 
    {

        public List<card_set> card_sets {get; set;}

        public List<card_image> card_images {get;set;}

        public List<card_price> card_prices {get;set;}
        



    }
}