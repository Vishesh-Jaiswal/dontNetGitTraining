using XYZHotelsApp.Models.DTOs;
namespace XYZHotelsApp.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}