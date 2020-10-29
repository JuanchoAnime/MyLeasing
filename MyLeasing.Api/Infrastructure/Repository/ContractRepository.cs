namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ContractRepository : IContractRepository
    {
        private readonly IPropertyRepository propertyRepository;
        private readonly ILesseeRepository lesseeRepository;
        private readonly DataContext dataContext;

        public ContractRepository(IPropertyRepository propertyRepository, ILesseeRepository lesseeRepository, 
            DataContext dataContext)
        {
            this.propertyRepository = propertyRepository;
            this.lesseeRepository = lesseeRepository;
            this.dataContext = dataContext;
        }

        public async Task<PropertyDto> SaveData(int property, ContractDto contract)
        {
            var propertyDto = await this.propertyRepository.FindAsync(property);
            var owner = propertyDto.Owner;
            var lessee = await lesseeRepository.FindById(contract.Lessee.Id);

            contract.Owner = owner;
            contract.Lessee = lessee;
            propertyDto.Contracts = propertyDto.Contracts ?? new List<ContractDto>();
            propertyDto.Contracts.Add(contract);
            dataContext.Properties.Update(propertyDto);
            dataContext.Entry(propertyDto).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            return await propertyRepository.FindById(property);
        }
    }
}
