using GS.Domain.Entities;

namespace GS.Domain.Repos
{
    public interface IPlatformRepo : IBaseRepo<PlatformType>
    {
        PlatformType Get(int id);
    }
}
