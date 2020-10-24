namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericRepository<Dto> : IRepository<Dto> where Dto : BaseEntity
    {
        private readonly DataContext _context;

        protected DbSet<Dto> Entity { get; }

        public GenericRepository(DataContext context)
        {
            _context = context;
            this.Entity = this._context.Set<Dto>();
        }

        public async Task<bool> Delete(int id)
        {
            var dto = await FindById(id);
            Entity.Remove(dto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Dto>> FindAll()
        {
            var list = await Entity.ToListAsync();
            return list;
        }

        public async Task<Dto> FindById(int id)
        {
            var dto = await Entity.FindAsync(id);
            if(dto==null)
                throw new Exception("Id no encontrado");
            return dto;
        }

        public async Task<Dto> Save(Dto entity)
        {
            await this.Entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Dto> Update(Dto entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                if (!OwnerDtoExists(entity.Id)) 
                    throw new Exception("Id no encontrado");
                else
                    throw new Exception(ex.Message);
            }
        }


        private bool OwnerDtoExists(int id)
        {
            return Entity.Any(e => e.Id == id);
        }
    }
}
