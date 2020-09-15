using CheckerApp.WebUI.ViewModels.Hardware;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Services
{
    public interface IHardwareService
    {
        Task<int> AddHardware(CreateHardwareVm command);

        Task<HardwareVm> GetHardware(int id);
    }
}
