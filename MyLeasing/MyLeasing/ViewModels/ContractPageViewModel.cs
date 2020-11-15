namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using Prism.Commands;
    using Prism.Navigation;

    public class ContractPageViewModel : ViewModelBase
    {
        private ContractResponse _contract;
        private string _nameProperty;

        public ContractPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ContractPage;
        }

        public ContractResponse Contract
        {
            get => _contract;
            set => SetProperty(ref _contract, value);
        }

        public DelegateCommand PopupCommand => new DelegateCommand(Popup);

        private async void Popup()
        {
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(Constants.ParamContract))
                Contract = parameters.GetValue<ContractResponse>(Constants.ParamContract);

            if (parameters.ContainsKey(Constants.ParamPropertyName)) {
                _nameProperty = parameters.GetValue<string>(Constants.ParamPropertyName);
                Title = $"{Languages.ContractDetailPage} {_nameProperty}";
            }
        }
    }
}
