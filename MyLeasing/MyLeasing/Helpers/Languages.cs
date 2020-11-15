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
    }
}
