using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckerApp.Mobile.Pages
{
    public partial class ContractsPage : ContentPage
    {
        public ContractsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback +=
                            (send, certificate, chain, errors) =>
                            {
                                return true;
                            };

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://192.168.0.103:5001");

            var response = await client.GetAsync("api/contract");

            TestLabel.Text = await response.Content.ReadAsStringAsync();
        }
    }
}
