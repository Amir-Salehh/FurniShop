using FurniShop.Application.Interfaces;
using FurniShop.Application.Security;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        public UserService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<bool> CheckExistAsync(string EmailMobile)
        {
            return await _userRepository.CheckExistUserAsync(EmailMobile);
        }

        public async Task<string> CheckLoginAsync(string emailPhone, string password, bool remmemberMe)
        {
            var user = await _userRepository.GetUserByEmailOrMobileAsync(emailPhone);

            if (user == null)
                throw new Exception("کاربر پیدا نشد");

            string hashedPassword = PasswordHelper.HashPasswordBase64(password.Trim(), user.saltpassword);

            if (!string.Equals(hashedPassword, user.Password, StringComparison.Ordinal)) throw new Exception();

            return GenerateToken(user, remmemberMe);
        }

        private string GenerateToken(User user, bool remmemberMe)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:key"]!);

            var expires = remmemberMe ? 7 * 24 * 60 : int.Parse(_config["Jwt:EpiresInMinutes"]!);
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),

            };

            foreach (var userRole in user.UserRoles)
            {
                claims.Add(new Claim(
                    ClaimTypes.Role, userRole.Role.RoleName)
                    );
            }

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expires),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> CheckUserAsync(string email, string PhoneNumber)
        {
            return await _userRepository.IsExistUserAsync(email.Trim().ToLower(), PhoneNumber);
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userRepository.CreateNewUserAsync(user);
        }

        public List<User> GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users.ToList();
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user!;
        }

    }
}
