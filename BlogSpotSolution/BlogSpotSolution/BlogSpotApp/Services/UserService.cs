using BlogSpotApp.Interfaces;
using BlogSpotApp.Models.DTOs;
using BlogSpotApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace BlogSpotApp.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<string, User> _repository;

        public UserService(IRepository<string, User> repository)
        {
            _repository = repository;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _repository.GetById(userDTO.User_email);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Password = "";
                return userDTO;
            }
            return null;
        }

        public UserDTO Register(UserDTO userDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                User_email = userDTO.User_email,
                User_name = userDTO.User_name,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                Key = hmac.Key,
                Role = userDTO.Role,
                RegistrationDate= DateTime.Now,
                ProfilePicture=""

            };
            var result = _repository.Add(user);
            if (result != null)
            {
                userDTO.Password = "";
                return userDTO;
            }
            return null;
        }
    }
}
