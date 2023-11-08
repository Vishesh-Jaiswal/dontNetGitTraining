using BlogSpotApp.Models.DTOs;

namespace BlogSpotApp.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}