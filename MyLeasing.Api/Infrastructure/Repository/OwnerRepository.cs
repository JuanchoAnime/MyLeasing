namespace MyLeasing.Api.Infrastructure.Repository
{
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;

    public class OwnerRepository: GenericRepository<OwnerDto> ,IOwnerRepository
    {
        public OwnerRepository(DataContext dataContext): base(dataContext)
        {
        }
    }
}
