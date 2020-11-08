namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using Prism.Commands;
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
        }

        public DelegateCommand GoBackComand => new DelegateCommand(GoBack);

        private async void GoBack() { 
            await NavigationService.GoBackAsync(); 
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Property = parameters.GetValue<PropertyResponse>(Constants.ParamProperty);
        }
    }
}
