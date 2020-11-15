namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.AdvancedRest;
    using MyLeasing.Common.Rest;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PropertyApplication: GenericApplication<PropertyRest, PropertyDto>
    {
        private readonly IPropertyRepository propertyRepository;
        private readonly IContractRepository contractRepository;
        private readonly IPropertyImageRepository propertyImageRepository;

        public PropertyApplication(IPropertyRepository propertyRepository, IMapper mapper, IPropertyImageRepository propertyImageRepository,
            IContractRepository contractRepository)
            : base(propertyRepository, mapper)
        {
            this.propertyRepository = propertyRepository;
            this.contractRepository = contractRepository;
            this.propertyImageRepository = propertyImageRepository;
        }

        public async Task<List<PropertyWithOwner>> GetPropertiesWithOwner()
        {
            var list = await propertyRepository.FindAll();
            list.ForEach(p => p.Owner.Properties = new List<PropertyDto>());
            return Mapper.Map<List<PropertyWithOwner>>(list);
        }

        public async override Task<PropertyRest> Save(PropertyRest entity)
        {
            entity.Contracts = new List<ContractRest>();
            entity.PropertiesImages = new List<PropertyImageRest>();
            var data = await this.propertyRepository.AddProperty(Mapper.Map<PropertyDto>(entity), entity.IdOwner);
            return Mapper.Map<PropertyRest>(data);
        }

        internal async Task<PropertyWithOwner> SaveImage(ImageRest imageRest)
        {
            var data = await propertyImageRepository.SaveData(imageRest);
            return Mapper.Map<PropertyWithOwner>(data);
        }

        public async Task<PropertyWithOwner> GetEntityInfoById(int id)
        {
            var dto = await propertyRepository.FindById(id);
            return Mapper.Map<PropertyWithOwner>(dto);
        }

        public async Task<PropertyWithOwner> SaveImage(int idProperty, IFormFile formFile)
        {
            var data = await propertyImageRepository.SaveData(idProperty, formFile);
            return Mapper.Map<PropertyWithOwner>(data);
        }

        internal async Task<PropertyWithOwner> SaveContract(int idProperty, ContractRest contractRest)
        {
            var data = await contractRepository.SaveData(idProperty, Mapper.Map<ContractDto>(contractRest)) ;
            return Mapper.Map<PropertyWithOwner>(data);
        }
    }
}
