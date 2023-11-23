using System.ComponentModel.DataAnnotations;
namespace BlogSpotApp.Models.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "User Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Username cannot be empty")]
        public string UserName { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}