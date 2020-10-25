namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile formFile);
    }
}
