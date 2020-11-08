namespace MyLeasing.Service
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using MyLeasing.Model;
    using MyLeasing.ViewModels;
    using Refit;
    using System;
    using System.Threading.Tasks;

    public class MyLeasingService
    {
        public async Task<Response<OwnerResponse>> GetOwnerByEmail(ViewModelBase viewModel,string email)
        {
            try
            {
                var owner = await RestService.For<IMyLeasingService>(viewModel.GetStringForDistionary(Constants.UrlApi))
                                    .GetOwnerByEmail(new Common.Rest.EmailRequest() { Email = email });
                if (owner == null)
                {
                    return new Response<OwnerResponse> {
                        IsSuccess = false,
                        Message = "User Or Password Incorrect"
                    };
                }
                return new Response<OwnerResponse>
                {
                    IsSuccess = true,
                    Result = owner
                };
            }
            catch (Exception ex)
            {
                return new Response<OwnerResponse> {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
