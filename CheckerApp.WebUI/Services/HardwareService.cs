using CheckerApp.WebUI.Enums;
using CheckerApp.WebUI.ViewModels.Hardware;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
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

        public async Task<HardwareVm> GetHardware(int id)
        {            
            var httpResponse = await _httpClient.GetAsync($"api/hardware/{id}");

            httpResponse.EnsureSuccessStatusCode();

            var jsonString = await httpResponse.Content.ReadAsStringAsync();

            var hardware = JsonConvert.DeserializeObject<HardwareVm>(jsonString);

            switch (hardware.HardwareType)
            {
                case HardwareType.Cabinet:
                    return JsonConvert.DeserializeObject<CabinetVm>(jsonString);
                case HardwareType.FlowComputer:
                    return JsonConvert.DeserializeObject<FlowComputerVm>(jsonString);
                case HardwareType.Flowmeter:
                    return JsonConvert.DeserializeObject<FlowmeterVm>(jsonString);
                case HardwareType.Network:
                    return JsonConvert.DeserializeObject<NetworkHardwareVm>(jsonString);
                case HardwareType.PLC:
                    return JsonConvert.DeserializeObject<PLCVm>(jsonString);
                case HardwareType.Pressure:
                    return JsonConvert.DeserializeObject<PressureVm>(jsonString);
                case HardwareType.Temperature:
                    return JsonConvert.DeserializeObject<TemperatureVm>(jsonString);
                case HardwareType.Valve:
                    return JsonConvert.DeserializeObject<ValveVm>(jsonString);
            }

            return null;
        }
    }
}
