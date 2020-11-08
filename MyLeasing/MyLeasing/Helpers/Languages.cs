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
    }
}
