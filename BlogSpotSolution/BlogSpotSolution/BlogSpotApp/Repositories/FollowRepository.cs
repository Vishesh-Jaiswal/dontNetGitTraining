using BlogSpotApp.Contexts;
using BlogSpotApp.Interfaces;
using BlogSpotApp.Models;
using System.Reflection.Metadata;

namespace BlogSpotApp.Repositories
{
    public class FollowRepository : IRepository<int, Follow>
    {
        private readonly BlogSpotContext _context;

        public FollowRepository(BlogSpotContext context)
        {
            _context = context;
        }

        public Follow Add(Follow follow)
        {
            _context.Follows.Add(follow);
            _context.SaveChanges();
            return follow;
        }

        public Follow Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IList<Follow> GetAll()
        {
            throw new NotImplementedException();
        }

        public Follow GetById(int key)
        {
            throw new NotImplementedException();
        }

        public Follow Update(Follow entity)
        {
            throw new NotImplementedException();
        }
    }
}
