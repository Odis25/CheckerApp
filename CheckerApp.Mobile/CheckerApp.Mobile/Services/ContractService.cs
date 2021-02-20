using CheckerApp.Mobile.Common;
using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Mobile.Services
{
    public class ContractService : IContractService
    {
        private readonly HttpClient _httpClient;

        public ContractService()
        {
            _httpClient = HttpClientHelper.GetHttpClient();
            //_httpClient.BaseAddress = new Uri("https://192.168.0.103:5001");
        }
        public async Task<ContractsListVm> GetContractsAsync()
        {
            try
            {
                var contracts = await _httpClient.GetFromJsonAsync<ContractsListVm>("api/contract");

                return contracts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
