using BlogSpotApp.Models;

namespace BlogSpotApp.Interfaces
{
    public interface ICommentService
    {
        public Comment AddComment(Comment comment);
    }
}
