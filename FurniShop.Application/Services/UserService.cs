using FurniShop.Application.DTOs;
using FurniShop.Application.DTOs.Auth;
using FurniShop.Application.Interfaces;
using FurniShop.Application.Security;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly IBankCartRepository _backCartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserRepository userRepository, IConfiguration config,
            IBankCartRepository backCartRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _config = config;
            _backCartRepository = backCartRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CheckExistAsync(string EmailMobile)
        {
            return await _userRepository.CheckExistUserAsync(EmailMobile);
        }

        public async Task<string> CheckLoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailOrMobileAsync(request.EmailPhone);

            if (user == null)
                throw new Exception("کاربر پیدا نشد");

            string hashedPassword = PasswordHelper.HashPasswordBase64(request.Password.Trim(), user.saltpassword);

            if (!string.Equals(hashedPassword, user.Password, StringComparison.Ordinal)) throw new Exception();

            return GenerateToken(user, request.RememberMe);
        }

        private string GenerateToken(User user, bool remmemberMe)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:key"]!);

            var expires = remmemberMe ? 7 * 24 * 60 : int.Parse(_config["Jwt:EpiresInMinutes"]!);
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim("LevelId", user.LevelId.ToString()),
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

        public async Task RegisterUserAsync(RegisterRequest request)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            string HashedPassword = PasswordHelper.HashPasswordBase64(request.Password, salt);

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Addresses = null,
                Password = HashedPassword,
                saltpassword = salt,
                CreatedAt = DateTime.UtcNow,
                UserRoles = new List<UserRoles>()
                {
                    new UserRoles { RoleId = 3 }
                },
            };

            if (request.CheckSeller)
            {
                user.UserRoles.Add(new UserRoles { RoleId = 2 });
                user.LevelId = 1;
            }

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

        public async Task<BankCartInformation?> GetCart()
        {
            int UserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            return await _backCartRepository.GetCart(UserId);
        }

        public async Task CreateCart(BankCartRequest request)
        {
            var BankCart = new BankCartInformation
            {
                CartNumber = request.CartNumber,
                BankName = request.CartName,
            };

            await _backCartRepository.Create(BankCart);
        }

        public async Task<bool> CheckHaveBankCart()
        {
            int UserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            return await _backCartRepository.CheckHaveBankCart(UserId);
        }

        public async Task<bool> CheckExistCart(int id)
        {
            return await _backCartRepository.CheckExistCart(id);
        }

        public async Task UpdateCart(BankCartRequest request)
        {
            int UserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var cart = await _backCartRepository.GetCart(UserId);

            cart!.CartNumber = request.CartNumber;
            cart.BankName = request.CartName;

            await _backCartRepository.Update(cart);
        }

        public async Task DeleteCart(int CartId)
        {
            var cart = await _backCartRepository.GetCartById(CartId);

            await _backCartRepository.Delete(cart!);
        }

    }
}
