using CheckerApp.Mobile.Common;
using CheckerApp.Mobile.Common.JsonConverters;
using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Mobile.Services
{
    public class ContractService : IContractService
    {
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public ContractService()
        {
            _httpClient = HttpClientHelper.GetHttpClient();
            _options = new JsonSerializerOptions { Converters = { new HardwareConverter(), new SoftwareConverter() } };
        }
        public async Task<ContractsListDto> GetContractsAsync()
        {
            try
            {
                var contracts = await _httpClient.GetFromJsonAsync<ContractsListDto>("api/contract", _options);

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
                var contract = await _httpClient.GetFromJsonAsync<ContractDto>($"api/contract/{id}", _options);

                return contract;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
