namespace MyLeasing.ViewModels
{
    using MyLeasing.Common.Response;
    using MyLeasing.Helpers;
    using MyLeasing.Views;
    using Newtonsoft.Json;
    using Prism.Navigation;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ContractsPageViewModel : ViewModelBase
    {
        private ObservableCollection<ContractResponse> _contract;
        private string _propertyName;

        public ContractsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ContractPage;

            var property = JsonConvert.DeserializeObject<PropertyResponse>(Settings.PropertyResponse);
            _propertyName = property.Neighborhood;
            Contracts = new ObservableCollection<ContractResponse>(property.Contracts);
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
            await NavigationService.NavigateAsync($"{nameof(ContractPage)}", (Constants.ParamContract, contract), (Constants.ParamPropertyName, _propertyName));
        }
    }
}
