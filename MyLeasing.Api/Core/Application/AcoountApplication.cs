namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Rest;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AcoountApplication
    {
        private readonly LesseeApplication _lesseeApplication;
        private readonly IMapper _mapper;
        private readonly OwnerApplication _ownerApplication;
        private readonly IUserHelper _userHelper;

        public AcoountApplication(LesseeApplication lesseeApplication, IMapper mapper, OwnerApplication ownerApplication, IUserHelper userHelper)
        {
            this._lesseeApplication = lesseeApplication;
            this._mapper = mapper;
            this._ownerApplication = ownerApplication;
            this._userHelper = userHelper;
        }

        public async Task<UserRest> SaveUser(AutoRegisterRest user)
        {
            UserRest userRest = null;
            if (user.Role.Equals(Helper.Constans.ROLE_OWNER)) {
                var owner = await _ownerApplication.Save(GetOwnerByAutoRegister(user));
                userRest =  owner.User;
            }
            else if (user.Role.Equals(Helper.Constans.ROLE_LESSEE)) {
                var lessee = await _lesseeApplication.Save(GetLesseeByAutoRegister(user));
                userRest =  lessee.User;
            }
            return userRest;
        }

        internal async Task ChangePassword(ChangePasswordRest changePassword)
        {
            var user = await _userHelper.GetUserByEmailAsync(changePassword.Email);
            if (user == null) throw new Exception("Email Not Exists");
            await _userHelper.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
        }

        internal async Task<UserRest> UpdateData(UserRest user)
        {
            var userDto = await _userHelper.GetUserByEmailAsync(user.Email);
            if (userDto == null) return null;
            userDto.Document = user.Document;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.Address = user.Address;
            userDto.PhoneNumber = user.PhoneNumber;
            await _userHelper.UpdateUserAsync(userDto);
            return _mapper.Map<UserRest>(userDto);
        }

        private OwnerRest GetOwnerByAutoRegister(AutoRegisterRest user) 
        {
            return new OwnerRest {
                Contracts = new List<ContractRest>(),
                Id = 0,
                Password = user.Password,
                Properties = new List<PropertyRest>(),
                User = user.User
            };
        }

        private LesseeRest GetLesseeByAutoRegister(AutoRegisterRest user)
        {
            return new LesseeRest {
                Contracts = new List<ContractRest>(),
                Id = 0,
                Password = user.Password,
                User = user.User
            };
        }
    }
}
