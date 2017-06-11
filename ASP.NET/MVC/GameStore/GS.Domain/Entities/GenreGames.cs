namespace GS.Domain.Entities
{
    public class GenreGame
    {
        public string GameId { get; private set; }
        public int GenreId { get; set; }

        public Game Game { get; set; }
        public Genre Genre { get; set; }
    }
}
