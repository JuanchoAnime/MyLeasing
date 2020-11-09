namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using MyLeasing.Views;
    using Newtonsoft.Json;
    using Prism.Navigation;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

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

        public ICommand GotoPropertyCommand => new Command(GotoProperty);

        private async void GotoProperty(object obj)
        {
            var property = obj as PropertyResponse;
            Settings.PropertyResponse = JsonConvert.SerializeObject(property);
            await NavigationService.NavigateAsync($"{nameof(HomeTabbedPage)}");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(Constants.ParamOwner)) {
                var _owner = parameters.GetValue<OwnerResponse>(Constants.ParamOwner);
                Properties = new ObservableCollection<PropertyResponse>(_owner.Properties);
                PropertyTypes = new ObservableCollection<string>(_owner.Properties.Select(p => p.PropertyType).Distinct());
            }
        }
    }
}
