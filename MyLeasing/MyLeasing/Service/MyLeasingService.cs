namespace MyLeasing.Service
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using MyLeasing.Model;
    using MyLeasing.ViewModels;
    using Plugin.Connectivity;
    using Refit;
    using System;
    using System.Threading.Tasks;

    public class MyLeasingService
    {
        public async Task<Response<OwnerResponse>> GetOwnerByEmailAsync(ViewModelBase viewModel,string email)
        {
            try
            {
                var owner = await RestService.For<IMyLeasingService>(viewModel.GetStringForDistionary(Constants.UrlApi))
                                    .GetOwnerByEmail(new Common.Rest.EmailRequest() { Email = email });
                if (owner == null) {
                    return new Response<OwnerResponse> {
                        IsSuccess = false,
                        Message = Languages.InvalidLogin
                    };
                }
                return new Response<OwnerResponse> {
                    IsSuccess = true,
                    Result = owner
                };
            }
            catch
            {
                return new Response<OwnerResponse> {
                    IsSuccess = false,
                    Message = Languages.InvalidLogin
                };
            }
        }

        public async Task<Response<string>> CheckConnectionAsync() 
        {
            if (!CrossConnectivity.Current.IsConnected)
                return new Response<string> { 
                    IsSuccess = false, 
                    Message = "Turn Off Conection" 
                };

            var ping = await CrossConnectivity.Current.IsRemoteReachable(Constants.UrlPing);
            if(!ping)
                return new Response<string> { 
                    IsSuccess = false, 
                    Message = "Check Internet Conection" 
                };

            return new Response<string> { IsSuccess = true };
        }
    }
}
