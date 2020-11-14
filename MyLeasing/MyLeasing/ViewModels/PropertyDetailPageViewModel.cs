namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using Newtonsoft.Json;
    using Prism.Navigation;

    public class PropertyDetailPageViewModel : ViewModelBase
    {
        private PropertyResponse _property;

        public PropertyResponse Property
        {
            get => _property;
            set => SetProperty(ref _property, value);
        }

        public PropertyDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Property = JsonConvert.DeserializeObject<PropertyResponse>(Settings.PropertyResponse);
            Title = Property.Neighborhood;
        }
    }
}
