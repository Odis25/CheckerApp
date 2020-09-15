using CheckerApp.WebUI.ViewModels.Contract;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Services
{
    public class ContractService : IContractService
    {
        private readonly HttpClient _httpClient;
        public ContractService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateContract(CreateContractVm command)
        {           
            return await _httpClient.PostJsonAsync<int>("api/contract", command);
        }

        public async Task<ContractDetailVm> GetContract(int id)
        {
            return await _httpClient.GetJsonAsync<ContractDetailVm>($"api/contract/{id}");
        }

        public async Task<ContractsListVm> GetContracts()
        {
            var discDoc = await _httpClient.GetDiscoveryDocumentAsync("");

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest 
            {
                Address = discDoc.TokenEndpoint,
                ClientId = "blazor_client_app",
                ClientSecret = "client_super_secret",
                Scope = "CheckerAppApi"
            });

            _httpClient.SetBearerToken(tokenResponse.AccessToken);

            var res =  await _httpClient.GetJsonAsync<ContractsListVm>("api/contract");
            return res;
        }
    }
}
