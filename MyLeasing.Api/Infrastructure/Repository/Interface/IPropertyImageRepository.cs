namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using Microsoft.AspNetCore.Http;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    public interface IPropertyImageRepository
    {
        Task<PropertyDto> SaveData(int property, IFormFile formFile);
    }
}
