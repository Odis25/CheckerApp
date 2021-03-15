using CheckerApp.Mobile.Models;
using System.Text.Json;
using Xamarin.Forms;

namespace CheckerApp.Mobile.ViewModels
{
    [QueryProperty(nameof(Content), nameof(Content))]
    public class ContractDetailsVm : BindableObject
    {
        public string Content { set => LoadContract(value); }

        public ContractDto Contract { get; set; }

        public void LoadContract(string jsonStr)
        {
            Contract = JsonSerializer.Deserialize<ContractDto>(jsonStr);
            OnPropertyChanged("Contract");
        }
    }
}
