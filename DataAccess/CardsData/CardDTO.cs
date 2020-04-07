using System;
using System.Collections.Generic;

namespace scrubcardshopAPI.DataAccess.CardsData
{
    public class CardDTO
    {
        public int id {get; set;}
        public string name {get; set;}
        public string type {get; set;}
        public string desc {get; set;}
        public string atk {get;set;}
        public string def {get;set;}
		public string level {get;set;}
        public string attribute {get;set;}
        public string race {get;set;}       
        public string archetype {get; set;}



        public class card_set
        {
            public string set_name {get; set;}
            public string set_code {get; set;}
            public string set_rarity {get; set;}
            public string set_price {get; set;}
        }

        public class card_image
        {
            public string image_url {get;set;}
            public string image_url_small {get; set;}
        }
        public class card_price
        {
            public string cardmarket_price {get;set;}
            public string tcgplayer_price {get;set;}
            public string ebay_price {get;set;}
        }
        public class banlist_info 
        {
            public string ban_tcg {get;set;}
            public string ban_ocg {get;set;}
        }

        public List<card_set> card_sets {get; set;}

        public List<card_image> card_images {get;set;}

        public List<card_price> card_prices {get;set;}
        

    }
}
