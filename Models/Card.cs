using System.Collections.Generic;

namespace scrubcardshopAPI.Models
{
    public class Card : BaseCard 
    {

        public ICollection<card_set> card_sets {get; set;}

        public ICollection<card_image> card_images {get;set;}

        public ICollection<card_price> card_prices {get;set;}
        



    }
}