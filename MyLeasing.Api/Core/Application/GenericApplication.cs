namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenericApplication<Rest, Dto> where Dto : BaseEntity
    {
        private IRepository<Dto> Repository { get; }

        protected IMapper Mapper { get; }

        public GenericApplication(IRepository<Dto> repository, IMapper mapper)
        {
            this.Repository = repository;
            this.Mapper = mapper;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var result = await Repository.Delete(id);
            return result;
        }

        public virtual async Task<List<Rest>> GetEntities()
        {
            var list = await Repository.FindAll();
            return Mapper.Map<List<Rest>>(list);
        }

        public virtual async Task<Rest> GetEntity(int id)
        {
            var dto = await Repository.FindById(id);
            return Mapper.Map<Rest>(dto);
        }

        public virtual async Task<Rest> Save(Rest entity)
        {
            var dto = await Repository.Save(Mapper.Map<Dto>(entity));
            return Mapper.Map<Rest>(dto);
        }

        public virtual async Task<Rest> Update(Rest entity)
        {
            var dto = await Repository.Update(Mapper.Map<Dto>(entity));
            return Mapper.Map<Rest>(dto);
        }
    }
}
