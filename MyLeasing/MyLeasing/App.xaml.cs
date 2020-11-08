namespace MyLeasing
{
    using Prism;
    using Prism.Ioc;
    using MyLeasing.ViewModels;
    using MyLeasing.Views;
    using Xamarin.Essentials.Interfaces;
    using Xamarin.Essentials.Implementation;
    using Xamarin.Forms;
    using MyLeasing.Service;

    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.Register<MyLeasingService>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertiesPage, PropertiesPageViewModel>();
        }
    }
}
