using System;
using System.Collections.Generic;

namespace GS.Domain.Entities
{
    public class Game
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Comment> Comments { get; set; }
        public IList<GenreGame> GenreGames { get; set; }
        public IList<PlatformTypeGame> PlatformTypeGames { get; set; }

        public Game()
        {
            Id = Guid.NewGuid().ToString();
            Comments = new List<Comment>();
            GenreGames = new List<GenreGame>();
            PlatformTypeGames = new List<PlatformTypeGame>();
        }

        public Game(string name, string description)
            : this()
        {            
            Name = name;
            Description = description;
        }
    }
}
