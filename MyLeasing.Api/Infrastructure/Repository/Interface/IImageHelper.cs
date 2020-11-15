namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Threading.Tasks;

    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile formFile);

        Task<string> UploadPhotoAsync(MemoryStream stream);
    }
}
