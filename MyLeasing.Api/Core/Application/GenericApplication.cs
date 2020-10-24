namespace MyLeasing.Api.Core.Application
{
    using MyLeasing.Api.Core.Application.Interface;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Mapper;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenericApplication<Rest, Dto>: IGenericApplication<Rest> where Dto: BaseEntity
    {
        protected IRepository<Dto> Repository { get; }
        protected GenericMapper<Rest, Dto> Mapper { get; }

        public GenericApplication(IRepository<Dto> repository, GenericMapper<Rest, Dto> mapper)
        {
            this.Repository = repository;
            this.Mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await Repository.Delete(id);
            return result;
        }

        public async Task<List<Rest>> GetEntities()
        {
            var list = await Repository.FindAll();
            return Mapper.GetRest(list);
        }

        public async Task<Rest> GetEntity(int id)
        {
            var dto = await Repository.FindById(id);
            return Mapper.GetRest(dto);
        }

        public async Task<Rest> Save(Rest entity)
        {
            var dto = await Repository.Save(Mapper.GetDto(entity));
            return Mapper.GetRest(dto);
        }

        public async Task<Rest> Update(Rest entity)
        {
            var dto = await Repository.Update(Mapper.GetDto(entity));
            return Mapper.GetRest(dto);
        }
    }
}
