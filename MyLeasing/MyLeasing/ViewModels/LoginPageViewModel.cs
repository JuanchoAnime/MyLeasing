namespace MyLeasing.ViewModels
{
    using MyLeasing.Helpers;
    using MyLeasing.Service;
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
            Password = string.Empty;
            IsRunning = true;
            IsEnabled = false;
            var result = await _myLeasingService.GetOwnerByEmail(this, Email);
            IsRunning = false;
            IsEnabled = true;
            if (!result.IsSuccess) { 
                await this.ShowMessage(result.Message);
                return;
            }
            await this.ShowMessage(result.Result.FullName, "Fuck Yeah");
            await NavigationService.NavigateAsync("PropertiesPage");
        }
    }
}
