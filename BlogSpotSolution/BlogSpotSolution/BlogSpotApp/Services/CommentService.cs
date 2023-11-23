using BlogSpotApp.Exceptions;
using BlogSpotApp.Interfaces;
using BlogSpotApp.Models;
using System.Reflection.Metadata;

namespace BlogSpotApp.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<string, User> _userRepository;
        private readonly IRepository<int, Blog> _blogRepository;
        private readonly IRepository<int, Comment> _commentRepository;

        public CommentService(IRepository<int, Blog> blogRepository, IRepository<string, User> userRepository, IRepository<int, Comment> commentRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }
        /// <summary>
        /// Add Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        /// <exception cref="BlogNotFoundException"></exception>
        /// <exception cref="NoSuchUserExists"></exception>
        public Comment AddComment(Comment comment)
        {
            var blogCheck = _blogRepository.GetAll().FirstOrDefault(c => c.BlogId == comment.BlogId);

            if (blogCheck == null)
            {
                throw new BlogNotFoundException();
            }
            var userCheck = _userRepository.GetAll().FirstOrDefault(u => u.UserEmail == comment.UserEmail);
            if (userCheck==null)
            {
                throw new NoSuchUserExists();
            }
            comment.CommentedAt = DateTime.Now;
            var result=_commentRepository.Add(comment);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
