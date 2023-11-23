using BlogSpotApp.Exceptions;
using BlogSpotApp.Interfaces;
using BlogSpotApp.Models;
using BlogSpotApp.Repositories;
using System.Reflection.Metadata;

namespace BlogSpotApp.Services
{
    public class FollowService : IFollowService
    {
        private readonly IRepository<string, User> _userRepository;
        private readonly IRepository<int, Follow> _followRepository;

        public FollowService(IRepository<string, User> userRepository, IRepository<int, Follow> followRepository)
        {
            _userRepository = userRepository;
            _followRepository = followRepository;
        }

        public Follow AddFollow(Follow follow)
        {
            var checkFollower = _userRepository.GetAll().FirstOrDefault(f => f.UserEmail == follow.FollowerEmail);
            var checkFollowed = _userRepository.GetAll().FirstOrDefault(f => f.UserEmail == follow.FollowedEmail);
            if (checkFollower != null && checkFollowed != null)
            {
                if (checkFollower.Role == "Reader" && checkFollowed.Role=="Blogger")
                {
                    var result = _followRepository.Add(follow);
                    return result;
                }
            }
            else
            {
                throw new NoSuchUserExists();
            }
            return null;
        }
    }
}
