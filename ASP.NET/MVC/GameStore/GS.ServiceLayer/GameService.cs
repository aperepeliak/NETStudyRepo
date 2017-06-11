using System;
using System.Collections.Generic;
using GS.Domain.Entities;
using GS.Domain.Services;
using GS.Domain.UoW;

namespace GS.ServiceLayer
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _uow;

        public GameService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddGame(string name, string description)
        {
            _uow.Games.Add(new Game(name, description));
            _uow.Complete();
        }

        public IEnumerable<Game> GetAll()
        {
            return _uow.Games.GetAll();
        }

        public Game GetGame(string key)
        {
            return _uow.Games.Get(key);
        }
    }
}
