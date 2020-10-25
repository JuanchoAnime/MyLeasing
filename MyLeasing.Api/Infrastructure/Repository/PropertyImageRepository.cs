namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.AspNetCore.Http;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
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
            var pi = new PropertyImageDto
            {
                Id = 0,
                ImageUrl = await imageHelper.UploadImageAsync(formFile),
                Property = await propertyRepository.FindAsync(property)
            };
            dataContext.PropertyImages.Add(pi);
            await dataContext.SaveChangesAsync();
            return await propertyRepository.FindById(property);
        }
    }
}
