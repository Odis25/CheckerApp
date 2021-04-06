using CheckerApp.Mobile.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace CheckerApp.Mobile.ViewModels
{
    public class ContractVm : BindableObject
    {
        public ContractDto Contract { get; set; }

        public ICommand GetDetailsCommand { get; }

        public ContractVm()
        {
            Contract = new ContractDto();

            GetDetailsCommand = new Command(GetDetailsAsync);
        }

        private async void GetDetailsAsync(object obj)
        {
            await Shell.Current.GoToAsync($"contract?ContractId={Contract.Id}");
        }
    }
}
