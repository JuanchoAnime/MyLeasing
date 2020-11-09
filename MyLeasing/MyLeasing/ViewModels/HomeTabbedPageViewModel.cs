namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using Newtonsoft.Json;
    using Prism.Navigation;

    public class HomeTabbedPageViewModel : ViewModelBase
    {
        public HomeTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = JsonConvert.DeserializeObject<PropertyResponse>(Settings.PropertyResponse).Neighborhood;
        }
    }
}
