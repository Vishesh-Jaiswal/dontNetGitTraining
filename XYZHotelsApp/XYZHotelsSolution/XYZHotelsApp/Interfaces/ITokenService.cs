using XYZHotelsApp.Models.DTOs;

namespace XYZHotelsApp.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}