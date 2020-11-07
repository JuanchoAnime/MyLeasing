namespace MyLeasing.Helpers
{
    using MyLeasing.Interfaces;
    using System;
    using System.Globalization;
    using System.Resources;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo cultureInfo;
        private const string resourceId = "MyLeasing.Resources.Resource";
        private static readonly Lazy<ResourceManager> resourceManager = new Lazy<ResourceManager>(() =>
            new ResourceManager(resourceId, typeof(TranslateExtension).GetType().Assembly)
        );

        public TranslateExtension() {
            cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null) return string.Empty;
            /*
            var translation = resourceManager.Value.GetString(Text, cultureInfo);
            if (translation == null) {
                translation = Text;
            }*/
            var translation = Text;
            return translation;
        }
    }
}
