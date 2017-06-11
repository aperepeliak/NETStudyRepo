using GS.Domain.Entities;
using GS.Domain.Repos;

namespace GS.DAL.Repos
{
    public class CommentRepo : BaseRepo<Comment>, ICommentRepo
    {
        public CommentRepo(AppContext context) : base(context)
        { }

        public Comment Get(int id)
        {
            return _table.Find(id);
        }
    }
}
