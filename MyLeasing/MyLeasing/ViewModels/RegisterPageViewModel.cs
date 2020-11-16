namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Rest;
    using MyLeasing.Helpers;
    using MyLeasing.Model;
    using MyLeasing.Service;
    using Prism.Commands;
    using Prism.Navigation;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class RegisterPageViewModel : ViewModelBase
    {
        private bool _isRunning;
        private bool _isEnabled;
        private string _password;
        private string _passwordConfirm;
        private readonly MyLeasingService _myLeasingService;

        #region Constanst

        public string DocumentPlaceHolder { get; set; }

        public string Loading { get; set; }

        public string EmailPlaceHolder { get; set; }

        public string PasswordPlaceHolder { get; set; }

        public string EmailText { get; set; }

        public string PasswordText { get; set; }

        public string DocumentText { get; set; }

        public string FirstNameText { get; set; }

        public string LastNameText { get; set; }

        public string AddressText { get; set; }

        public string PhoneText { get; set; }

        public string PasswordConfirmText { get; set; }

        public string RoleText { get; set; }

        public string FirstNamePlaceHolder { get; set; }

        public string LastNamePlaceHolder { get; set; }

        public string AddressPlaceHolder { get; set; }

        public string PhonePlaceHolder { get; set; }

        public string RolePlaceHolder { get; set; }

        public string PasswordConfirmPlaceHolder { get; set; }

        #endregion

        public RegisterPageViewModel(INavigationService navigationService, MyLeasingService myLeasingService) 
            : base(navigationService)
        {
            Title = Languages.SignUp;
            IsEnabled = true;
            TranslateConstants();
            Roles = new ObservableCollection<string>(new List<string> { "Owner", "Lessee" });
            this._myLeasingService = myLeasingService;
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

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set => SetProperty(ref _passwordConfirm, value);
        }

        public string Document { get; set; }

        public ObservableCollection<string> Roles { get; set; }

        public string Role { get ; set ; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DelegateCommand PopupCommand => new DelegateCommand(Popup);

        public DelegateCommand RegisterCommand => new DelegateCommand(Register);

        private async void Register()
        {
            //TODO: Validar que ninguno este vacio
            if (!Password.Equals(PasswordConfirm))
            {
                await ShowMessage(Languages.ConfirmInvalid);
                return;
            }

            IsRunning = true;
            IsEnabled = false;
            var user = new AutoRegisterRest { 
                Password = Password,
                Role = Role,
                User = new UserRest {
                    Address = Address,
                    Document = Document,
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = Phone,
                    UserName = Email
                }
            };
            var result = await _myLeasingService.RegisterUser(this, user);
            IsRunning = false;
            IsEnabled = true;
            if (!result.IsSuccess)
            {
                await ShowMessage(result.Message);
                return;
            }
        }

        private async void Popup()
        {
            await NavigationService.GoBackAsync();
        }

        private void TranslateConstants()
        {
            Loading = Languages.Loading;
            EmailPlaceHolder = Languages.EnterEmail;
            PasswordPlaceHolder = Languages.EnterPassword;
            EmailText = Languages.EmailPlaceHolder;
            PasswordText = Languages.PasswordPlaceHolder;
            DocumentText = Languages.DocumentText;
            FirstNameText = Languages.FirstNameText;
            LastNameText = Languages.LastNameText;
            AddressText = Languages.AddressText;
            PhoneText = Languages.PhoneText;
            RoleText = Languages.RoleText;
            PasswordConfirmText = Languages.PasswordConfirmText;
            DocumentPlaceHolder = Languages.DocumentPlaceHolder;
            FirstNamePlaceHolder = Languages.FirstNamePlaceHolder;
            LastNamePlaceHolder = Languages.LastNamePlaceHolder;
            AddressPlaceHolder = Languages.AddressPlaceHolder;
            PhonePlaceHolder = Languages.PhonePlaceHolder;
            RolePlaceHolder = Languages.RolePlaceHolder;
            PasswordConfirmPlaceHolder = Languages.PasswordConfirmPlaceHolder;
        }
    }
}
