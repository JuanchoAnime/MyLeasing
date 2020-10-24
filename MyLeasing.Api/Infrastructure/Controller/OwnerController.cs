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
    }
}
