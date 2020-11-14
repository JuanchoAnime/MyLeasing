namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Core.Helper;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    public class ManagerApplication : GenericApplication<ManagerRest, ManagerDto>
    {
        private readonly IUserHelper _userHelper;

        public ManagerApplication(IManagerRepository repository, IMapper mapper, IUserHelper userHelper) 
            : base(repository, mapper) { this._userHelper = userHelper; }

        public override async Task<ManagerRest> Save(ManagerRest entity)
        {
            var user = await this.CreateUser(entity.User, entity.Password);
            if (user != null) {
                entity.User = user;
                return await base.Save(entity);
            }
            throw new System.Exception("User With this email already exists");
        }

        private async Task<UserRest> CreateUser(UserRest user, string password)
        {
            var result = await _userHelper.AddUserAsync(Mapper.Map<UserDto>(user), password);
            if (result.Succeeded)
            {
                var userDto = await _userHelper.GetUserByEmailAsync(user.Email);
                await _userHelper.AddUserToRoleAsync(userDto, Constans.ROLE_MANAGER);
                return Mapper.Map<UserRest>(userDto);
            }
            return null;
        }
    }
}
