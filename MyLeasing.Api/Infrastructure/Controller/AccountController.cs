namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AcoountApplication _acoountApplication;

        public AccountController(AcoountApplication acoountApplication)
        {
            this._acoountApplication = acoountApplication;
        }

        [HttpPost]
        public async Task<IActionResult> AutoRegisterApp(AutoRegisterRest user)
        {
            var response = await _acoountApplication.SaveUser(user);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserRest user)
        {
            var response = await _acoountApplication.UpdateData(user);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRest changePassword)
        {
            await _acoountApplication.ChangePassword(changePassword);
            return Ok();
        }
    }
}
