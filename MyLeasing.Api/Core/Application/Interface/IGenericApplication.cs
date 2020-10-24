namespace MyLeasing.Api.Core.Application.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericApplication<Rest>
    {
        Task<List<Rest>> GetEntities();

        Task<Rest> GetEntity(int id);

        Task<Rest> Save(Rest entity);

        Task<Rest> Update(Rest entity);

        Task<bool> Delete(int id);
    }
}
