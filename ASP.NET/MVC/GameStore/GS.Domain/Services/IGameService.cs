using GS.Domain.Entities;
using System.Collections.Generic;

namespace GS.Domain.Services
{
    public interface IGameService
    {
        Game GetGame(string key);
        IEnumerable<Game> GetAll();
        void AddGame(string name, string description);
    }
}
