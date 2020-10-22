using CheckerApp.Application.Checks.Commands.CreateContractCheck;
using CheckerApp.Application.Checks.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var hardware = JsonSerializer.Deserialize<ContractCheckVm>(jsonString, opt);
            var result = hardware.GetType();

            return Ok();
        }
    }
}
