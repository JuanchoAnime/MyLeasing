namespace MyLeasing.Api.Infrastructure.Repository
{
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;

    public class PropertyRepository: GenericRepository<PropertyDto>, IPropertyRepository
    {
        public PropertyRepository(DataContext dataContext): base(dataContext)
        {

        }
    }
}
