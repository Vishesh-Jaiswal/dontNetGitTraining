using System.ComponentModel.DataAnnotations;

namespace BlogSpotApp.Models
{
    public class User
    {
        [Key]
        public string User_email { get; set; }
        public string User_name { get; set; }
        public byte[] Password { get; set; }
        public string Role { get; set; }
        public byte[] Key { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}