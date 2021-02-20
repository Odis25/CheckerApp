using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CheckerApp.Mobile.ViewModels
{
    public class ContractsVm : INotifyPropertyChanged
    {
        private ObservableCollection<ContractDto> _contracts;
        private readonly IContractService _contractService;

        public ObservableCollection<ContractDto> Contracts 
        {
            get => _contracts;
            set 
            {
                _contracts = value;
                OnPropertyChanged(nameof(Contracts));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task GetContractsAsync()
        {
            var contracts = await _contractService.GetContractsAsync();

            Contracts = new ObservableCollection<ContractDto>(contracts.Contracts);
        }

        public ContractsVm(IContractService contractService)
        {
            _contractService = contractService;
            //Device.BeginInvokeOnMainThread(GetContractsAsync);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
