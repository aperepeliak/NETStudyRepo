using GS.Domain.Repos;

namespace GS.Domain.UoW
{
    public interface IUnitOfWork
    {
        IGameRepo Games { get; }
        ICommentRepo Comments { get; }

        void Complete();
    }
}
