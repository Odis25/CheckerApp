using CheckerApp.WebUI.ViewModels.Hardware;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Services
{
    public class HardwareService : IHardwareService
    {
        private readonly HttpClient _httpClient;
        public HardwareService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> AddHardware(CreateHardwareVm command)
        {
            return await _httpClient.PostJsonAsync<int>("api/hardware", command);
        }
    }
}
