using BlogSpotApp.Models;

namespace BlogSpotApp.Interfaces
{
    public interface IFollowService
    {
        public Follow AddFollow(Follow follow);
    }
}
