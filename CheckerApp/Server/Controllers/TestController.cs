using CheckerApp.Application.Documents.Queries;
using CheckerApp.Server.Common.JsonConverters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
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
            var httpResponse = await httpClient.GetAsync($"api/document/4");

            httpResponse.EnsureSuccessStatusCode();

            var jsonString = await httpResponse.Content.ReadAsStringAsync();
            var opt = new JsonSerializerOptions();
            opt.PropertyNameCaseInsensitive = true;
            opt.Converters.Add(new CheckStatusConverter());
            var hardware = JsonSerializer.Deserialize<ContractCheckStatusVm>(jsonString, opt);
            var result = hardware.GetType();
            var h = (CabinetCheckStatusDto)hardware.HardwareChecks.First();
            return Ok();
        }
    }
}
