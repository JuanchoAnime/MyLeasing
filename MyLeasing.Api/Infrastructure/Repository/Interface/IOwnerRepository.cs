namespace MyLeasing.Api.Infrastructure.Repository.Interface
{
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    public interface IOwnerRepository: IRepository<OwnerDto>
    {
        Task<OwnerDto> FindAsync(int id);

        Task<OwnerDto> GetOwnerByEmail(EmailRequest emailRequest);
    }
}
