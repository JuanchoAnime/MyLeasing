namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using System.Threading.Tasks;

    public interface IContractRepository
    {
        Task<PropertyDto> SaveData(int property, ContractDto contract);
    }
}
