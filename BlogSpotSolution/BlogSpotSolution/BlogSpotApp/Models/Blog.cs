using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogSpotApp.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserEmail { get; set; }
        public DateTime? CreationDate { get; set; }
        [JsonIgnore]
        public User? Author { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
