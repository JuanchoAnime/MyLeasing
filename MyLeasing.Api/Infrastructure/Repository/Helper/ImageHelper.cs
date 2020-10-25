namespace MyLeasing.Api.Infrastructure.Repository.Helper
{
    using Microsoft.AspNetCore.Http;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile formFile)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}.png";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "images\\Properties", file);
            using (var stream = new FileStream(path, FileMode.Create)) 
            {
                await formFile.CopyToAsync(stream);
            }
            return $"~/images/Properties/{file}";
        }
    }
}
