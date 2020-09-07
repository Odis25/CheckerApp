using CheckerApp.Domain.Entities.ContractEntities;
using CheckerApp.Domain.Entities.HardwareEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Contract> Contracts { get; set; }
        DbSet<Hardware> Hardwares { get; set; }
        DbSet<CabinetHardware> CabinetHardwares { get; set; }
        DbSet<ControllerHardware> ControllerHardwares { get; set; }
        DbSet<MeasurementHardware> Measurements { get; set; }
        DbSet<FlowMeterHardware> FlowMeterHardwares { get; set; }
        DbSet<ValveHardware> ValveHardwares { get; set; }
        DbSet<NetworkHardware> NetworkHardwares { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
