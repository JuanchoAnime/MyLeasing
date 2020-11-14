namespace MyLeasing.Api.Infrastructure.Repository
{
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;

    public class ManagerRepository:GenericRepository<ManagerDto>, IManagerRepository
    {
        public ManagerRepository(DataContext ctx): base(ctx)
        {
        }
    }
}
