namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly OwnerApplication ownerApplication;

        public OwnersController(OwnerApplication ownerApplication)
        {
            this.ownerApplication = ownerApplication;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<IEnumerable<OwnerRest>> GetOwners()
        {
            var list = await ownerApplication.GetEntities();
            return list;
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerDto([FromRoute] int id)
        {
            var ownerDto = await ownerApplication.GetEntity(id);
            return Ok(ownerDto);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnerDto([FromRoute] int id, [FromBody] OwnerRest owner)
        {
            if (id != owner.Id) { return BadRequest(); }
            var result = await ownerApplication.Update(owner);
            return Ok(result);
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<IActionResult> PostOwnerDto([FromBody] OwnerRest owner)
        {
            var result = await ownerApplication.Save(owner);
            return Ok(result);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnerDto([FromRoute] int id)
        {
            await ownerApplication.Delete(id);
            return Ok();
        }
    }
}