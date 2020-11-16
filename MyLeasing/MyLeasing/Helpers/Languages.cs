namespace MyLeasing.Helpers
{
    using MyLeasing.Interfaces;
    using MyLeasing.Resources;
    using Xamarin.Forms;

    public static class Languages
    {
        static Languages()
        {
            var cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = cultureInfo;
            DependencyService.Get<ILocalize>().SetLocalize(cultureInfo);
        }

        public static string Accept => Resource.Accept;

        public static string Error => Resource.Error;

        public static string EmailError => Resource.EmailError;

        public static string PasswordError => Resource.PasswordError;

        public static string Login => Resource.Login;

        public static string EnterEmail => Resource.EnterEmail;

        public static string EnterPassword => Resource.EnterPassword;

        public static string EmailPlaceHolder => Resource.EmailPlaceHolder;

        public static string PasswordPlaceHolder => Resource.PasswordPlaceHolder;

        public static string InvalidLogin => Resource.InvalidLogin;

        public static string ContractPage => Resource.ContractPage;

        public static string ContractDetailPage => Resource.ContractDetailPage;

        public static string CheckConection => Resource.CheckConection;

        public static string TurnConection => Resource.TurnConection;

        public static string Loading => Resource.Loading;

        public static string Properties => Resource.Properties;

        public static string Contracts => Resource.Contracts;

        public static string ModifyUser => Resource.ModifyUser;

        public static string Maps => Resource.Maps;

        public static string LogOut => Resource.LogOut;

        public static string SignUp => Resource.SignUp;

        public static string TextRegister => Resource.TextRegister;

        public static string ForgotPassword => Resource.ForgotPassword;

        public static string Rememberme => Resource.Rememberme;

        public static string DocumentText => Resource.DocumentText;

        public static string FirstNameText => Resource.FirstNameText;

        public static string LastNameText => Resource.LastNameText;

        public static string AddressText => Resource.AddressText;

        public static string PhoneText => Resource.PhoneText;

        public static string RoleText => Resource.RoleText;

        public static string PasswordConfirmText => Resource.PasswordConfirmText;

        public static string DocumentPlaceHolder => Resource.DocumentPlaceHolder;

        public static string FirstNamePlaceHolder => Resource.FirstNamePlaceHolder;

        public static string LastNamePlaceHolder => Resource.LastNamePlaceHolder;

        public static string AddressPlaceHolder => Resource.AddressPlaceHolder;

        public static string PhonePlaceHolder => Resource.PhonePlaceHolder;

        public static string RolePlaceHolder => Resource.RolePlaceHolder;

        public static string PasswordConfirmPlaceHolder => Resource.PasswordConfirmPlaceHolder;

        public static string ConfirmInvalid => Resource.ConfirmInvalid;
    }
}
