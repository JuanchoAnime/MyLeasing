﻿namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OwnerRepository: GenericRepository<OwnerDto>, IOwnerRepository
    {
        public OwnerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async override Task<List<OwnerDto>> FindAll()
        {
            var owners = await Entity.Include(o => o.User)
                .ToListAsync();
            return owners;
        }

        public async Task<OwnerDto> FindAsync(int id)
        {
            var dto = await Entity.FindAsync(id);
            if (dto == null)
                throw new Exception("Id no encontrado");
            return dto;
        }

        public async override Task<OwnerDto> FindById(int id)
        {
            var dto = await  Entity.Include(o => o.User)
                .Include(o => o.Properties).ThenInclude(p => p.PropertiesImages)
                .Include(o => o.Properties).ThenInclude(p => p.PropertyType)
                .Include(o => o.Contracts).ThenInclude(c => c.Lessee).ThenInclude(l => l.User)
                .Where(o => o.Id.Equals(id))
                .FirstOrDefaultAsync();
            if (dto == null)
                throw new Exception("Id no encontrado");
            dto.Contracts.ToList().ForEach(c => {
                c.Owner = null;
                c.Lessee.Contracts = new List<ContractDto>();
            });
            dto.Properties.ToList().ForEach(p => p.Contracts = new List<ContractDto>());
            return dto;
        }
    }
}
