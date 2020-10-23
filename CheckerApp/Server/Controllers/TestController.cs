using CheckerApp.Application.Checks.Queries;
using CheckerApp.Shared.Common.JsonConverters;
using CheckerApp.Shared.Models.Checks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Server.Controllers
{
    public class TestController : ApiController
    {
        private readonly HttpClient httpClient;

        public TestController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:5001");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpResponse = await httpClient.GetAsync($"api/check/4");
            var res = await httpClient.GetFromJsonAsync<ContractCheckVm>($"api/check/4");
            httpResponse.EnsureSuccessStatusCode();

            var jsonString = await httpResponse.Content.ReadAsStringAsync();
            var opt = new JsonSerializerOptions 
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new HardwareConverter() }
            };

            var hardware = JsonSerializer.Deserialize<ContractCheckVm>(jsonString, opt);

            return Ok();
        }
    }
}
