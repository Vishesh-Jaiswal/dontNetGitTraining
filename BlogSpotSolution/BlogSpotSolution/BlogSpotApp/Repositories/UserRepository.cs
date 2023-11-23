using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BlogSpotApp.Interfaces;
using BlogSpotApp.Contexts;
using BlogSpotApp.Models;

namespace BlogSpotApp.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly BlogSpotContext _context;


        public UserRepository(BlogSpotContext context)
        {
            _context = context;
        }
        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(string key)
        {
            var user = GetById(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        public IList<User> GetAll()
        {
            if (_context.Users.Count() == 0)
                return null;
            return _context.Users.ToList();
        }

        public User GetById(string key)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserEmail == key);
            return user;
        }

        public User Update(User entity)
        {
            var user = GetById(entity.UserName);
            if (user != null)
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            return null;
        }
    }
}