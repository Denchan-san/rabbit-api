using Rabbit_API.Models.Dto.Users;

namespace Rabbit_API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool isUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
