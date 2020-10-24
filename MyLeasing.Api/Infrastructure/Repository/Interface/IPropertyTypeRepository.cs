namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPropertyTypeRepository: IRepository<PropertyTypeDto>
    {
        Task<List<PropertyTypeDto>> FindAllWithProperties();
    }
}
