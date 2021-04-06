using CheckerApp.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckerApp.Mobile.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContractDetail : ContentPage
    {
        private readonly ContractDetailVm _viewModel;
        public ContractDetail()
        {           
            InitializeComponent();

            _viewModel = new ContractDetailVm();

            BindingContext = _viewModel;            
        }
    }
}