namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using MyLeasing.Views;
    using Newtonsoft.Json;
    using Prism.Commands;
    using Prism.Navigation;
    using System;
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
            GetData();
        }

        public ICommand GotoPropertyCommand => new Command(GotoProperty);
        public DelegateCommand ShowMenuCommand => new DelegateCommand(ShowMenu);

        private void ShowMenu()
        {
            App.Master.IsPresented = true;
        }

        private void GetData()
        {
            var _owner = JsonConvert.DeserializeObject<OwnerResponse>(Settings.Owner);
            Properties = new ObservableCollection<PropertyResponse>(_owner.Properties);
            PropertyTypes = new ObservableCollection<string>(_owner.Properties.Select(p => p.PropertyType).Distinct());
        }

        private async void GotoProperty(object obj)
        {
            var property = obj as PropertyResponse;
            Settings.PropertyResponse = JsonConvert.SerializeObject(property);
            await NavigationService.NavigateAsync($"{nameof(HomeTabbedPage)}");
        }
    }
}
