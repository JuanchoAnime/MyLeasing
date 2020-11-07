namespace MyLeasing.ViewModels
{
    using Prism.Commands;
    using Prism.Navigation;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class LoginPageViewModel : ViewModelBase
    {
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Login";
            IsEnabled = true;
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
            if (string.IsNullOrEmpty(Email)) {
                await this.ShowMessage("You Must Enter An Email");
                return;
            }
            if (string.IsNullOrEmpty(Password)) {
                await this.ShowMessage("You Must Enter a Password");
                return;
            }
            await this.ShowMessage(msg: "Fuck Yeah!!!", title: "Ok");
        }
    }
}
