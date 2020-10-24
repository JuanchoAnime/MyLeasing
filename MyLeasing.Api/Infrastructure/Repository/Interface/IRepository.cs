namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<Dto> where Dto: BaseEntity
    {
        Task<List<Dto>> FindAll();

        Task<Dto> FindById(int id);

        Task<Dto> Save(Dto entity);

        Task<Dto> Update(Dto entity);

        Task<bool> Delete(int id);
    }
}
