namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly OwnerApplication _ownerApplication;
        private readonly LesseeApplication _lesseeApplication;

        public AccountController(OwnerApplication ownerApplication, LesseeApplication lesseeApplication)
        {
            this._ownerApplication = ownerApplication;
            this._lesseeApplication = lesseeApplication;
        }

        [HttpPost]
        public async Task<IActionResult> AutoRegisterApp(AutoRegisterRest user)
        {
            if (user.Role.Equals(Core.Helper.Constans.ROLE_OWNER))
            {
                var owner = await _ownerApplication.Save(new OwnerRest
                {
                    Contracts = new List<ContractRest>(),
                    Id = 0,
                    Password = user.Password,
                    Properties = new List<PropertyRest>(),
                    User = user.User
                });
                return Ok(owner);
            }
            else if (user.Role.Equals(Core.Helper.Constans.ROLE_LESSEE))
            {
                var lessee = await _lesseeApplication.Save(new LesseeRest
                {
                    Contracts = new List<ContractRest>(),
                    Id = 0,
                    Password = user.Password,
                    User = user.User
                });
                return Ok(lessee);
            }

            return BadRequest();
        }
    }
}
