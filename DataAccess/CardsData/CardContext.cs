using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

using scrubcardshopAPI.DataAccess;

namespace scrubcardshopAPI.DataAccess.CardsData
{
    public class CardContext : ICardContext
    {
        private readonly string _cardlist;
        private readonly List<CardDTO> _cardlist2;

        public CardContext (IConfiguration config)
        {
           var assembly = Assembly.GetEntryAssembly();
           var resourceStream = assembly.GetManifestResourceStream("scrubcardshopAPI.Data.yugioh.json");
           using (var reader = new StreamReader(resourceStream))
           {
                _cardlist = reader.ReadToEnd();  
                
                _cardlist2 = JsonConvert.DeserializeObject<List<CardDTO>>(_cardlist);
           }

        }
        public List<CardDTO> CardList => _cardlist2;
    }
}