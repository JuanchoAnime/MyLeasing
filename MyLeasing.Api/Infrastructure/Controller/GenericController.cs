namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    public class GenericController<Rest, Dto> : ControllerBase where Dto : BaseEntity where Rest : BaseRest
    {
        private GenericApplication<Rest, Dto> Application { get; }

        public GenericController(GenericApplication<Rest, Dto> application)
        {
            this.Application = application;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<Rest>> Get()
        {
            var list = await Application.GetEntities();
            return list;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            var entities = await Application.GetEntity(id);
            return Ok(entities);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] Rest entity)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != entity.Id) { return BadRequest(); }
            var result = await Application.Update(entity);
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] Rest entity)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            entity.Id = 0;
            var result = await Application.Save(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            await Application.Delete(id);
            return Ok();
        }

    }
}
