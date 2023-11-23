using BlogSpotApp.Contexts;
using BlogSpotApp.Interfaces;

using BlogSpotApp.Models;
using BlogSpotApp.Repositories;

namespace BlogSpotApp.Repositories
{

    public class CommentRepository : IRepository<int, Comment>
    {
        private readonly BlogSpotContext _context;

        public CommentRepository(BlogSpotContext context)
        {
            _context = context;
        }

        public Comment Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public Comment Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int key)
        {
            throw new NotImplementedException();
        }

        public Comment Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
