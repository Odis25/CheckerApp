using CheckerApp.Mobile.Models;
using System;
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
            GetDetailsCommand = new Command(GetDetails);
            Contract = new ContractDto();
        }

        private void GetDetails(object obj)
        {           
            throw new NotImplementedException();
        }
    }
}
