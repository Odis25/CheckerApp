using CheckerApp.Mobile.ViewModels;
using Xamarin.Forms;

namespace CheckerApp.Mobile.Views.Pages
{
    public partial class Contracts : ContentPage
    {
        private readonly ContractsVm _viewModel;

        public Contracts()
        {
            InitializeComponent();

            _viewModel = DependencyService.Resolve<ContractsVm>();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            await _viewModel.GetContractsAsync();

            base.OnAppearing();
        }
    }
}
