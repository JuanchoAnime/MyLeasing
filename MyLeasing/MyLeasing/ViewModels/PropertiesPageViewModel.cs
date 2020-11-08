namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using Prism.Navigation;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class PropertiesPageViewModel : ViewModelBase
    {
        private ObservableCollection<PropertyResponse> _properties;
        private ObservableCollection<string> _propertyTypes;

        public ObservableCollection<string> PropertyTypes 
        {
            get => _propertyTypes;
            set => SetProperty(ref _propertyTypes, value);
        }

        public ObservableCollection<PropertyResponse> Properties
        {
            get => _properties;
            set => SetProperty(ref _properties, value);
        }

        public PropertiesPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var owner = parameters.GetValue<OwnerResponse>(Constants.ParamOwner);
            Properties = new ObservableCollection<PropertyResponse>(owner.Properties);
            PropertyTypes = new ObservableCollection<string>(Properties.Select(p => p.PropertyType).Distinct());
        }
    }
}
