namespace MyLeasing.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Navigation;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PropertiesPageViewModel : ViewModelBase
    {
        public PropertiesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
