namespace MyLeasing.ViewModels
{
    using MyLeasing.Helpers;
    using MyLeasing.Service;
    using MyLeasing.Views;
    using Prism.Commands;
    using Prism.Navigation;

    public class LoginPageViewModel : ViewModelBase
    {
        private readonly MyLeasingService _myLeasingService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(INavigationService navigationService, MyLeasingService myLeasingService) 
            : base(navigationService)
        {
            Title = Languages.Login;
            IsEnabled = true;
            this._myLeasingService = myLeasingService;
        }

        public DelegateCommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new DelegateCommand(Login);
                return _loginCommand;
            }
        }

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
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

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await this.ShowMessage(Languages.EmailError);
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await this.ShowMessage(Languages.PasswordError);
                return;
            }
            IsRunning = true;
            IsEnabled = false;

            var response = await _myLeasingService.CheckConnectionAsync();
            if (!response.IsSuccess) {
                IsRunning = false;
                IsEnabled = true;
                await this.ShowMessage(response.Message);
                return;
            }

            var result = await _myLeasingService.GetOwnerByEmailAsync(this, Email);
            Password = string.Empty;
            if (!result.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await this.ShowMessage(result.Message);
                return;
            }
            await NavigationService.NavigateAsync($"{nameof(PropertiesPage)}", (Constants.ParamOwner, result.Result));
            IsRunning = false;
            IsEnabled = true;
        }
    }
}
