using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Services
{
    public interface IHardwareService
    {
        Task<int> AddHardware();
    }
}
