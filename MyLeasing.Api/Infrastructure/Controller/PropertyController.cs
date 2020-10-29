namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.IO;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : GenericController<PropertyRest, PropertyDto>
    {
        private readonly PropertyApplication _propertyApplication;

        public PropertyController(PropertyApplication propertyApplication)
            : base(propertyApplication)
        {
            this._propertyApplication = propertyApplication;
        }

        public override async Task<IActionResult> Get()
        {
            var list = await _propertyApplication.GetPropertiesWithOwner();
            return Ok(list);
        }

        public override async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await this._propertyApplication.GetEntityInfoById(id);
            return Ok(data);
        }

        [HttpPost("property/{idProperty}/AddImage")]
        public async Task<IActionResult> AddImage(int idProperty, IFormFile image)
        {
            var data = await this._propertyApplication.SaveImage(idProperty, image);
            return Ok(data);
        }

        [HttpPost("property/{idProperty}/AddContract")]
        public async Task<IActionResult> AddContract(int idProperty, ContractRest contractRest)
        {
            var data = await this._propertyApplication.SaveContract(idProperty, contractRest);
            return Ok(data);
        }
    }
}
