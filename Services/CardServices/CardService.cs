using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;



using scrubcardshopAPI.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace scrubcardshopAPI.Services
{
    public class CardService 
    {

        private readonly string _cardlist;
        private readonly List<Card> _cardlist2;
        public CardService(IConfiguration config)
        {

           var assembly = Assembly.GetEntryAssembly();
           var resourceStream = assembly.GetManifestResourceStream("scrubcardshopAPI.Data.yugioh.json");
           using (var reader = new StreamReader(resourceStream))
           {
                _cardlist = reader.ReadToEnd();  
                
                _cardlist2 = JsonConvert.DeserializeObject<List<Card>>(_cardlist);
           }

            //_cardlist = _cardlist2.ToObject<List<Card>>();

        }
        public List<Card> Get()
        {            
            //System.Diagnostics.Debug.WriteLine(_cardlist2);
            return _cardlist2;

            //return _users.Find(todo => true).ToList();
        }

        public List<Card> Get(string cardname)
        { 
            var card = _cardlist2.Where(x => x.name == cardname).ToList();
            return card;
        }

    }
    
}