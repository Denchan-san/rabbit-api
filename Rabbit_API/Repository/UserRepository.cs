using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rabbit_API.Data;
using Rabbit_API.Models;
using Rabbit_API.Models.Dto.Users;
using Rabbit_API.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rabbit_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration,
    UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool isUniqueUser(string email)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.ApplicationUsers
                .FirstOrDefault(u => u.Email == loginRequestDTO.Email.ToLower());

            bool isVlaid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

            if (user == null || isVlaid == false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            //if user was found generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user),
            };

            return loginResponseDTO;
        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new()
            {
                Email = registrationRequestDTO.Email,
                UserName = registrationRequestDTO.Email,  // Використовуйте Email як UserName
                NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
                NormalizedUserName = registrationRequestDTO.Email.ToUpper(), // Використовуйте нормалізований Email
                Name = registrationRequestDTO.Name,
                AvatarUrl = registrationRequestDTO.AvatarUrl
            };


            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers
                        .FirstOrDefault(u => u.Email == registrationRequestDTO.Email);
                    if (userToReturn == null)
                    {
                        Console.Error.WriteLine($"Error: USERTORETURN IS NULL!");

                    }
                    return _mapper.Map<UserDTO>(userToReturn);
                }
                else
                {
                    // Логування помилки
                    foreach (var error in result.Errors)
                    {
                        Console.Error.WriteLine($"Error: {error.Code} - {error.Description}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine($"Exception occurred: {ex.Message}");

            }

            return null;
        }

    }
}
