namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using Microsoft.AspNetCore.Identity;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        Task<UserDto> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserDto user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserDto user, string roleName);

        Task<bool> IsUserInRoleAsync(UserDto user, string roleName);

        Task<SignInResult> LoginAsync(LoginRequest login);

        Task<IdentityResult> ChangePasswordAsync(UserDto user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(UserDto userDto);
    }
}
