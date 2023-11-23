using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogSpotApp.Models
{
    public class User
    {
        [Key]
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public string Role { get; set; }
        public byte[] Key { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
        [JsonIgnore]
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Follow> Followers{ get; set; }
        public ICollection<Follow> Follows { get; set; }
    }
}