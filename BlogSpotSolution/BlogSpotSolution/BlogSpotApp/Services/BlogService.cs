using BlogSpotApp.Interfaces;
using BlogSpotApp.Models;
using BlogSpotApp.Models.DTOs;
using BlogSpotApp.Repositories;
using BlogSpotApp.Exceptions;

namespace BlogSpotApp.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<int, Blog> _blogRepository;
        private readonly IRepository<string, User> _userRepository;

        public BlogService(IRepository<int, Blog> blogRepository, IRepository<string, User> userRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }
        /// <summary>
        /// Add Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns>blog</returns>
        /// <exception cref="NoSuchUserExists"></exception>
        public Blog AddPost(Blog blog)
        {

            User author = _userRepository.GetById(blog.UserEmail);
            if(author != null)
            {
                blog.CreationDate = DateTime.Now;
                if (blog.Content.Length > 10)
                {
                    var result = _blogRepository.Add(blog);
                    return result;
                }
            }
            if(author== null)
            {
                throw new NoSuchUserExists();
            }
            return null;
        }
 
        /// <summary>
        /// Method for deleting blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns>blog</returns>
        /// <exception cref="BlogNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="CouldNotDelete"></exception>
        public Blog DeletePost(Blog blog)
        {
            var blogCheck=_blogRepository.GetAll().FirstOrDefault(b=>b.BlogId==blog.BlogId);

            if (blogCheck == null)
            {
                throw new BlogNotFoundException();
            }
            if (blogCheck.UserEmail != blog.UserEmail)
            {

                throw new UnauthorizedAccessException("You are not authorized to delete this blog post.");
            }
            var result = _blogRepository.Delete(blogCheck.BlogId);
            if (result == null)
            {
                throw new CouldNotDelete();
            }
            return blog;
        }

        public Blog EditPost(Blog blog)
        {
            var checkBlog=_blogRepository.GetAll().FirstOrDefault(b=>b.BlogId == blog.BlogId);
            if (checkBlog == null)
            {
                throw new BlogNotFoundException();
            }
            if(checkBlog.UserEmail != blog.UserEmail)
            {

                throw new UnauthorizedAccessException("You are not authorized to edit this blog post.");
            }
            blog.CreationDate = checkBlog.CreationDate;
            var result = _blogRepository.Update(blog);
            if (result == null)
            {
                throw new CouldNotEdit();
            }
            return blog;
        }

        public List<Blog> GetBlogs()
        {
            var blogs = _blogRepository.GetAll();
            if (blogs != null)
            {
                return blogs.ToList();
            }
            throw new NoBlogsAvailableException();
        }
    }
}
