using System.Text.Json.Serialization;

namespace BlogSpotApp.Models
{
    public class Follow
    {
        public int FollowId { get; set; }

        // Foreign key relationships
        public string FollowerEmail { get; set; }
        [JsonIgnore]
        public User? Follower { get; set; }

        public string FollowedEmail { get; set; }
        [JsonIgnore]
        public User? Followed { get; set; }
    }
}
