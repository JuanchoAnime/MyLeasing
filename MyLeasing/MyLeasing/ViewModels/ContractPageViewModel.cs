namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using Prism.Navigation;

    public class ContractPageViewModel : ViewModelBase
    {
        private ContractResponse _contract;

        public ContractPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ContractDetailPage;
        }

        public ContractResponse Contract
        {
            get => _contract;
            set => SetProperty(ref _contract, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (!parameters.ContainsKey(Constants.ParamContract))
                await ShowMessage("Exception Paramas Contract Invalid");
            Contract = parameters.GetValue<ContractResponse>(Constants.ParamContract);
        }
    }
}
