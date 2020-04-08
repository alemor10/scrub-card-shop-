using scrubcardshopAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scrubcardshopAPI.Services.CardServices
{
    public interface ICardService
    {
        Task<List<Card>> GetCards();
        Task<Card> GetCard(string name);
        Task CreateDeckList(createCardListRequest createRequest);    
    }
}