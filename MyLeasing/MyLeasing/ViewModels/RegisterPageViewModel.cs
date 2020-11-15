namespace MyLeasing.ViewModels
{
    using MyLeasing.Helpers;
    using Prism.Commands;
    using Prism.Navigation;

    public class RegisterPageViewModel : ViewModelBase
    {
        private bool _isRunning;
        private bool _isEnabled;

        #region Constanst

        public string Loading { get; set; }

        #endregion

        public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.SignUp;
            IsEnabled = true;
            TranslateConstants();
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public DelegateCommand PopupCommand => new DelegateCommand(Popup);

        private async void Popup()
        {
            await NavigationService.GoBackAsync();
        }

        private void TranslateConstants()
        {
            Loading = Languages.Loading;
        }
    }
}
