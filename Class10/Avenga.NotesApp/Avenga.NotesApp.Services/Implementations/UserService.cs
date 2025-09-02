using Avenga.NotesApp.DataAccess.Interfaces;
using Avenga.NotesApp.Domain.Models;
using Avenga.NotesApp.Dtos.UserDtos;
using Avenga.NotesApp.Services.Interfaces;
using Avenga.NotesApp.Shared.CustomExceptions;
using System.Security.Cryptography;
using System.Text;

namespace Avenga.NotesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string LoginUser(LoginUserDto loginUserDto)
        {
            if (string.IsNullOrEmpty(loginUserDto.Username) || string.IsNullOrEmpty(loginUserDto.Password))
            {
                throw new UserDataException("Username and password are required.");
            }
            
        }

        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            //1. Validate
            ValidateUser(registerUserDto);

            //2. Hash the password
            // MD5 hash algorithm is used here for simplicity, but in a real-world application
            // use a stronger hashing algorithm like bcrypt or Argon2.
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();


            // Convert the password string to a byte array
            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerUserDto.Password);
            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hash = Encoding.ASCII.GetString(hashedBytes);

            //3. Create the user
            User user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.Username,
                Password = hash // Will save the hashed password in our database not the plain text one inputed by the user
            };
            _userRepository.Add(user);
        }

        private void ValidateUser(RegisterUserDto registerUserDto)
        {
            if (string.IsNullOrEmpty(registerUserDto.Username) || string.IsNullOrEmpty(registerUserDto.Password))
            {
                throw new UserDataException("Username and password are required.");
            }
            if (registerUserDto.Username.Length > 30)
            {
                throw new UserDataException("Username cannot exceed 30 characters.");
            }
            if (!string.IsNullOrEmpty(registerUserDto.FirstName) && registerUserDto.FirstName.Length > 50)
            {
                throw new UserDataException("First name cannot exceed 50 characters.");
            }
            if (!string.IsNullOrEmpty(registerUserDto.LastName) && registerUserDto.LastName.Length > 50)
            {
                throw new UserDataException("First name cannot exceed 50 characters.");
            }
            if (registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                throw new UserDataException("Passwords must match!");
            }

            var userDb = _userRepository.GetUserByUsername(registerUserDto.Username);
            if (userDb != null)
            {
                throw new UserDataException("Username is already taken.");
            }
        }
    }
}
