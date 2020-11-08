namespace MyLeasing.Service
{
    using MyLeasing.Common.Response;
    using MyLeasing.Common.Rest;
    using Refit;
    using System.Threading.Tasks;

    public interface IMyLeasingService
    {
        [Post("/api/owner/getOwnerByEmail")]
        Task<OwnerResponse> GetOwnerByEmail([Body] EmailRequest emailRequest);
    }
}
