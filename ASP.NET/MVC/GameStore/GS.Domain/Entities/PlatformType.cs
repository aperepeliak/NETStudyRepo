using System.Collections.Generic;

namespace GS.Domain.Entities
{
    public class PlatformType
    {
        public int Id { get; private set; }
        public string Type { get; set; }

        public IList<PlatformTypeGame> PlatformTypeGames { get; set; }

        public PlatformType()
        {
            PlatformTypeGames = new List<PlatformTypeGame>();
        }
    }
}
