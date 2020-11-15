namespace MyLeasing.ViewModels
{
    using MyLeasing.Helpers;
    using MyLeasing.Model;
    using MyLeasing.Views;
    using Prism.Navigation;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LeasingMasterDetailViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItemViewModel> _menu;

        public LeasingMasterDetailViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoadMenu();
        }

        public ObservableCollection<MenuItemViewModel> MyMenu
        {
            get => _menu;
            set => SetProperty(ref _menu, value);
        }
        private void LoadMenu()
        {
            var menu = new List<Menu> {
                new Menu { Icon = "home", PageName = $"{nameof(PropertiesPage)}", Title = Languages.Properties },
                new Menu { Icon = "tasks", PageName = $"{nameof(MyContractsPage)}", Title = Languages.Contracts },
                new Menu { Icon = "user", PageName = $"{nameof(ModifyUserPage)}", Title = Languages.ModifyUser },
                new Menu { Icon = "ic_pin_drop", PageName = $"{nameof(MapsPage)}", Title = Languages.Maps},
                new Menu { Icon = "ic_logout", PageName = $"{nameof(LoginPage)}", Title = Languages.LogOut },
            };
            MyMenu = new ObservableCollection<MenuItemViewModel>(menu.Select(m =>
                new MenuItemViewModel(NavigationService) { Icon = m.Icon, PageName = m.PageName, Title = m.Title }
            ).ToList());
        }
    }
}
