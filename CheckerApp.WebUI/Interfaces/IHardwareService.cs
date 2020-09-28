using CheckerApp.WebUI.ViewModels.Hardware;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Interfaces
{
    public interface IHardwareService
    {
        Task<int> AddHardware(CreateHardwareVm command);

        Task<HardwareVm> GetHardware(int id);
    }
}
