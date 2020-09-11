using CheckerApp.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckerApp.WebApi.Controllers
{
    public class AccountController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
