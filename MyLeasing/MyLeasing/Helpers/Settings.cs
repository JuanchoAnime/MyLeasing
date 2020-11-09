namespace MyLeasing.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public class Settings
    {
        private const string _PropertyResKey = "propertyResponse";
        private static readonly string _settingsDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string PropertyResponse
        {
            get => AppSettings.GetValueOrDefault(_PropertyResKey, _settingsDefault);
            set => AppSettings.AddOrUpdateValue(_PropertyResKey, value);
        }
    }
}
