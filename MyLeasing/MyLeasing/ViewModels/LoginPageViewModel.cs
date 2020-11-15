namespace MyLeasing.ViewModels
{
    using MyLeasing.Helpers;
    using MyLeasing.Service;
    using MyLeasing.Views;
    using Newtonsoft.Json;
    using Prism.Commands;
    using Prism.Navigation;
    using Xamarin.Forms;

    public class LoginPageViewModel : ViewModelBase
    {
        private readonly MyLeasingService _myLeasingService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;

        #region Contants

        public string Email { get; set; }

        public string EnterEmail { get; set; }

        public string EnterPassword { get; set; }

        public string EmailPlaceHolder { get; set; }

        public string PasswordPlaceHolder { get; set; }

        public string Loading { get; set; }

        public string Rememberme { get; set; }

        public string SignUp { get; set; }

        public string TextRegister { get; set; }

        public string ForgotPassword { get; set; }

        #endregion

        public LoginPageViewModel(INavigationService navigationService, MyLeasingService myLeasingService)
            : base(navigationService)
        {
            Title = Languages.Login;
            IsEnabled = true;
            this._myLeasingService = myLeasingService;
            TranslateConstants();
        }

        public DelegateCommand SignUpCommand => new DelegateCommand(SignUpAsync);

        public DelegateCommand LoginCommand => new DelegateCommand(Login);

        public bool IsRecord { get; set; }

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
            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                Password = string.Empty;
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
            Settings.Owner = JsonConvert.SerializeObject(result.Result);
            await NavigationService.NavigateAsync($"/{nameof(LeasingMasterDetail)}/{nameof(NavigationPage)}/{nameof(PropertiesPage)}");
            IsRunning = false;
            IsEnabled = true;
        }

        private async void SignUpAsync()
        {

        }

        private void TranslateConstants()
        {
            EnterEmail = Languages.EnterEmail;
            EnterPassword = Languages.EnterPassword;
            EmailPlaceHolder = Languages.EmailPlaceHolder;
            PasswordPlaceHolder = Languages.PasswordPlaceHolder;
            Loading = Languages.Loading;
            ForgotPassword = Languages.ForgotPassword;
            TextRegister = Languages.TextRegister;
            SignUp = Languages.SignUp;
            Rememberme = Languages.Rememberme;
        }
    }
}
