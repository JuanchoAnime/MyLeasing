namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController: GenericController<OwnerRest, OwnerDto>
    {
        private readonly OwnerApplication _ownerApplication;

        public OwnerController(OwnerApplication ownerApplication):base(ownerApplication)
        {
            this._ownerApplication = ownerApplication;
        }

        [HttpPost("{owner}/AddProperty")]
        public async Task<IActionResult> AddProperty([FromRoute(Name = "owner")] int idOwner, [FromBody] PropertyRest property)
        {
            property.IdOwner = idOwner;
            var data = await this._ownerApplication.AddProperty(property);
            return Ok(data);
        }
    }
}
