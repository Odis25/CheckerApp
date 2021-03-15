using CheckerApp.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckerApp.Mobile.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContractDetails : ContentPage
    {
        private readonly ContractDetailsVm _viewModel;
        public ContractDetails()
        {           
            InitializeComponent();

            _viewModel = new ContractDetailsVm();

            BindingContext = _viewModel;            
        }
    }
}