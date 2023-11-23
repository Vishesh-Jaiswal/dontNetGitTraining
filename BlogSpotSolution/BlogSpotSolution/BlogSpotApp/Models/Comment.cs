using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogSpotApp.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime? CommentedAt { get; set; }

        // Foreign key relationships

        public string UserEmail { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog? BlogPost { get; set; }
    }
}