namespace MyLeasing.Api.Infrastructure.Repository
{
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;

    public class PropertyTypeRepository: GenericRepository<PropertyTypeDto>, IPropertyTypeRepository
    {
        public PropertyTypeRepository(DataContext dataContext): base(dataContext)
        {
        }
    }
}
