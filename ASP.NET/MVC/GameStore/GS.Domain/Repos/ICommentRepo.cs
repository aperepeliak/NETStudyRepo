using GS.Domain.Entities;

namespace GS.Domain.Repos
{
    public interface ICommentRepo : IBaseRepo<Comment>
    {
        Comment Get(int id);
    }
}
