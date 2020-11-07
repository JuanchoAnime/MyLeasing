﻿namespace MyLeasing.ViewModels
{
    using Prism.Mvvm;
    using Prism.Navigation;
    using System.Threading.Tasks;

    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        protected async Task ShowMessage(string msg, string title = "Error", string aceptar = "Accept")
        {
            await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert(title: title, message: msg, cancel: aceptar);
        }
    }
}
