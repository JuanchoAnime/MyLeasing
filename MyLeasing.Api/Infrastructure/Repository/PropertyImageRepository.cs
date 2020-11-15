namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.AspNetCore.Http;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Rest;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class PropertyImageRepository: IPropertyImageRepository
    {
        private readonly DataContext dataContext;
        private readonly IPropertyRepository propertyRepository;
        private readonly IImageHelper imageHelper;

        public PropertyImageRepository(DataContext dataContext, IPropertyRepository propertyRepository, IImageHelper imageHelper)
        {
            this.dataContext = dataContext;
            this.propertyRepository = propertyRepository;
            this.imageHelper = imageHelper;
        }

        public async Task<PropertyDto> SaveData(int property, IFormFile formFile)
        {
            var propertyDto = await propertyRepository.FindById(property);
            if (propertyDto == null) throw new Exception("Property Not Found");
            var pi = new PropertyImageDto
            {
                Id = 0,
                ImageUrl = await imageHelper.UploadImageAsync(formFile),
                Property = propertyDto
            };
            dataContext.PropertyImages.Add(pi);
            return propertyDto;
        }

        public async Task<PropertyDto> SaveData(ImageRest imageRest)
        {
            var property = await propertyRepository.FindById(imageRest.PropertyId);
            if (property == null) throw new Exception("Property Not Found");
            var pi = new PropertyImageDto
            {
                Id = imageRest.Id,
                ImageUrl = await imageHelper.UploadPhotoAsync(new MemoryStream(imageRest.ImageArray)),
                Property = property
            };
            dataContext.PropertyImages.Add(pi);
            await dataContext.SaveChangesAsync();
            return property;
        }
    }
}
