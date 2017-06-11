using System.Collections.Generic;

namespace GS.Domain.Entities
{
    public class Genre
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int? ParentGenreId { get; set; }

        public Genre ParentGenre { get; set; }
        public IList<Genre> ChildGenres { get; set; }

        public IList<GenreGame> GenreGames { get; set; }

        public Genre()
        {
            ChildGenres = new List<Genre>();
            GenreGames = new List<GenreGame>();
        }
    }
}
