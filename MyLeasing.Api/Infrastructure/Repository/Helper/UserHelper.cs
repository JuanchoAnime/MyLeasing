namespace MyLeasing.Api.Infrastructure.Repository.Helper
{
    using Microsoft.AspNetCore.Identity;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserDto> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserDto> _signInManager;

        public UserHelper(UserManager<UserDto> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserDto> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }
    
        public async Task<IdentityResult> AddUserAsync(UserDto user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserDto user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var existRol = await _roleManager.RoleExistsAsync(roleName);
            if (!existRol) 
            {
                await _roleManager.CreateAsync(new IdentityRole {
                    Name = roleName
                });
            }
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(UserDto user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginRequest login)
        {
            return await _signInManager.PasswordSignInAsync(
                login.UserName, login.Password, false, true );
        }
    }
}
