using CheckerApp.Shared.Hardware;
using System.Threading.Tasks;

namespace CheckerApp.Server.Common.Interfaces
{
    public interface IHardwareService
    {
        Task<int> AddHardware(CreateHardwareVm command);

        Task<HardwareVm> GetHardware(int id);
    }
}
