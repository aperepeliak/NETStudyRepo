using GH.WebUI.Core.Models;

namespace GH.WebUI.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
    }
}