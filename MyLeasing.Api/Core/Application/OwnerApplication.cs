namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Core.Helper;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Response;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OwnerApplication : GenericApplication<OwnerRest, OwnerDto>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUserHelper _userHelper;

        public OwnerApplication(IOwnerRepository ownerRepository, IMapper mapper, IUserHelper userHelper)
            : base(ownerRepository, mapper)
        {
            this._ownerRepository = ownerRepository;
            this._userHelper = userHelper;
        }

        public async override Task<OwnerRest> Save(OwnerRest entity)
        {
            var user = await this.CreateUser(entity.User, entity.Password);
            if(user != null) 
            {
                entity.User = user;
                entity.Contracts = new List<ContractRest>();
                entity.Properties = new List<PropertyRest>();
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
                await _userHelper.AddUserToRoleAsync(userDto, Constans.ROLE_OWNER);
                return Mapper.Map<UserRest>(userDto);
            }
            return null;
        }

        public async Task<OwnerResponse> GetOwnerByEmail(EmailRequest emailRequest) 
        {
            var owner = await _ownerRepository.GetOwnerByEmail(emailRequest);
            return Mapper.Map<OwnerResponse>(owner);
        }
    }
}
