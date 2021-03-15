using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using CheckerApp.Mobile.Views.Pages;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows.Input;
using Xamarin.Forms;

namespace CheckerApp.Mobile.ViewModels
{
    public class ContractVm : BindableObject
    {
        private readonly IContractService _contractService;

        public ContractDto Contract { get; set; }

        public ICommand GetDetailsCommand { get; }

        public ContractVm()
        {
            _contractService = DependencyService.Resolve<IContractService>();
            Contract = new ContractDto();
            GetDetailsCommand = new Command(GetDetailsAsync);
        }

        private async void GetDetailsAsync(object obj)
        {
            var contract = await _contractService.GetContractAsync(Contract.Id);

            Routing.RegisterRoute(nameof(ContractDetails), typeof(ContractDetails));

            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

            var json = JsonSerializer.Serialize(contract, options);

            await Shell.Current.GoToAsync($"{nameof(ContractDetails)}?Content={json}");
        }
    }
}
