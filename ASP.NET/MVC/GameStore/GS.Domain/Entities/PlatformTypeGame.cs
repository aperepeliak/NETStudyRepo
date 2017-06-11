namespace GS.Domain.Entities
{
    public class PlatformTypeGame
    {
        public string GameId { get; private set; }
        public int PlatformTypeId { get; set; }

        public Game Game { get; set; }
        public PlatformType PlatformType { get; set; }
    }
}
