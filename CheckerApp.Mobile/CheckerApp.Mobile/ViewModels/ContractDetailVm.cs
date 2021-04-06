using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using System;
using Xamarin.Forms;

namespace CheckerApp.Mobile.ViewModels
{
    [QueryProperty(nameof(ContractId), nameof(ContractId))]
    public class ContractDetailVm : BindableObject
    {
        private readonly IContractService _contractService;

        private ContractDto _contract;

        public string ContractId { set => LoadContractAsync(Uri.UnescapeDataString(value ?? string.Empty)); }

        public ContractDto Contract 
        { 
            get => _contract;
            set 
            {
                _contract = value;
                OnPropertyChanged();
            } 
        }

        public ContractDetailVm()
        {
            _contractService = DependencyService.Resolve<IContractService>();
        }

        public async void LoadContractAsync(string contractId)
        {
            Contract = await _contractService.GetContractAsync(int.Parse(contractId));
        }
    }
}
