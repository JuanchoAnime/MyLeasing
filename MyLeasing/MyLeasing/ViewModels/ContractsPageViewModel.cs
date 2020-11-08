namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using Prism.Navigation;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ContractsPageViewModel : ViewModelBase
    {
        private ObservableCollection<ContractResponse> _contract;

        public ContractsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public ObservableCollection<ContractResponse> Contracts
        {
            get => _contract;
            set => SetProperty(ref _contract, value);
        }

        public ICommand SelectContractCommand => new Command(SelectContract);

        private async void SelectContract(object obj)
        {
            var contract = obj as ContractResponse;
            await NavigationService.NavigateAsync($"nameof(ContractPage)", (Constants.ParamContract, contract));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var property = parameters.GetValue<PropertyResponse>(Constants.ParamProperty);
            Contracts = new ObservableCollection<ContractResponse>(property.Contracts);
        }
    }
}
