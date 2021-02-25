using CheckerApp.Mobile.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckerApp.Mobile.ViewModels
{
    public class ContractsVm : BindableObject
    {
        private ObservableCollection<ContractVm> _contracts;
        private readonly IContractService _contractService;

        public ObservableCollection<ContractVm> Contracts 
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

            var contractsVm = contracts.Contracts.Select(c => new ContractVm { Contract = c });

            Contracts = new ObservableCollection<ContractVm>(contractsVm);
        }

        public ContractsVm()
        {
            _contractService = DependencyService.Resolve<IContractService>();
        }
    }
}
