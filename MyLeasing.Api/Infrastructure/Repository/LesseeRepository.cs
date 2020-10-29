namespace MyLeasing.Api.Infrastructure.Repository
{
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;

    public class LesseeRepository: GenericRepository<LesseeDto> ,ILesseeRepository
    {
        public LesseeRepository(DataContext dataContext): base(dataContext)
        {

        }
    }
}
