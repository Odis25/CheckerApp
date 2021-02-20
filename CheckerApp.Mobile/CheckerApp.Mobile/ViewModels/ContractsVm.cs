using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckerApp.Mobile.ViewModels
{
    public class ContractsVm : BindableObject
    {
        private ObservableCollection<ContractDto> _contracts;
        private readonly IContractService _contractService;

        public ObservableCollection<ContractDto> Contracts 
        {
            get => _contracts;
            set 
            {
                _contracts = value;
                OnPropertyChanged();
            }
        }

        public async Task GetContractsAsync()
        {
            var contracts = await _contractService.GetContractsAsync();

            Contracts = new ObservableCollection<ContractDto>(contracts.Contracts);
        }

        public ContractsVm()
        {
            _contractService = DependencyService.Resolve<IContractService>();
        }
    }
}
