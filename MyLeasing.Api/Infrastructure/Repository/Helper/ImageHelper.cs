namespace MyLeasing.Api.Infrastructure.Repository.Helper
{
    using Microsoft.AspNetCore.Http;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class ImageHelper : IImageHelper
    {
        public static string FOLDER = "images\\Properties";

        public async Task<string> UploadImageAsync(IFormFile formFile)
        {
            var file = $"{Guid.NewGuid()}.png";
            var path = Path.Combine(Directory.GetCurrentDirectory(), FOLDER, file);
            using (var stream = new FileStream(path, FileMode.Create)) 
            {
                await formFile.CopyToAsync(stream);
            }
            return $"~/images/Properties/{file}";
        }

        public async Task<string> UploadPhotoAsync(MemoryStream stream) 
        {
            try
            {
                var name = $"{Guid.NewGuid()}.jpg";
                stream.Position = 0;
                var path = Path.Combine(Directory.GetCurrentDirectory(), FOLDER, name);
                await File.WriteAllBytesAsync(path, stream.ToArray());
                return $"~/images/Properties/{name}";
            }
            catch {
                throw new Exception("F Bro...");
            }
        }
    }
}
