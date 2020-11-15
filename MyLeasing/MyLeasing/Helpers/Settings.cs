namespace MyLeasing.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public class Settings
    {
        private const string _propertyResKey = "propertyResponse";
        private const string _owner = "ownerResponse";
        private static readonly string _settingsDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string PropertyResponse
        {
            get => AppSettings.GetValueOrDefault(_propertyResKey, _settingsDefault);
            set => AppSettings.AddOrUpdateValue(_propertyResKey, value);
        }
        public static string Owner
        {
            get => AppSettings.GetValueOrDefault(_owner, _settingsDefault);
            set => AppSettings.AddOrUpdateValue(_owner, value);
        }
    }
}
