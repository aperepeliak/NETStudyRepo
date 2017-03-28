using GH.WebUI.Models;

namespace GH.WebUI.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
    }
}