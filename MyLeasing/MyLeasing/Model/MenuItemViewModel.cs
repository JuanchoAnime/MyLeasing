namespace MyLeasing.Model
{
    using System.Threading.Tasks;
    using MyLeasing.Views;
    using Prism.Commands;
    using Prism.Navigation;
    using Xamarin.Forms;

    public class MenuItemViewModel: Menu
    {
        private readonly INavigationService _navigationService;

        public MenuItemViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public DelegateCommand GotoMenuCommand => new DelegateCommand(GotoMenu);

        private void GotoMenu() { Go(); }

        private async Task Go()
        {
            if (PageName.Equals(nameof(LoginPage)))
                await _navigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(LoginPage)}");
            else
                await _navigationService.NavigateAsync($"/{nameof(LeasingMasterDetail)}/{nameof(NavigationPage)}/{PageName}");
        }
    }
}
