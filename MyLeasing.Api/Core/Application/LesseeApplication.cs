namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Core.Helper;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Rest;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LesseeApplication : GenericApplication<LesseeRest, LesseeDto>
    {
        private readonly IUserHelper _userHelper;

        public LesseeApplication(ILesseeRepository repository, IMapper mapper, IUserHelper userHelper)
            : base(repository, mapper)
        {
            this._userHelper = userHelper;
        }

        public async override Task<LesseeRest> Save(LesseeRest entity)
        {
            var user = await this.CreateUser(entity.User, entity.Password);
            if (user != null)
            {
                entity.User = user;
                entity.Contracts = new List<ContractRest>();
                return await base.Save(entity);
            }
            throw new Exception("User With this email already exists");
        }

        private async Task<UserRest> CreateUser(UserRest user, string password)
        {
            var result = await _userHelper.AddUserAsync(Mapper.Map<UserDto>(user), password);
            if (result.Succeeded)
            {
                var userDto = await _userHelper.GetUserByEmailAsync(user.Email);
                await _userHelper.AddUserToRoleAsync(userDto, Constans.ROLE_LESSEE);
                return Mapper.Map<UserRest>(userDto);
            }
            return null;
        }
    }
}
