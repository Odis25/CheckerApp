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
        }
        public async Task<ContractsListDto> GetContractsAsync()
        {
            try
            {
                var contracts = await _httpClient.GetFromJsonAsync<ContractsListDto>("api/contract");

                return contracts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContractDto> GetContractAsync(int id)
        {
            try
            {
                var contract = await _httpClient.GetFromJsonAsync<ContractDto>($"api/contract/{id}");

                return contract;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
