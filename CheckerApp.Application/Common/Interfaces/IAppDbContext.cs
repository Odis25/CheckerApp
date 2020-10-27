using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Entities.ContractEntities;
using CheckerApp.Domain.Entities.Documents;
using CheckerApp.Domain.Entities.HardwareEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Contract> Contracts { get; set; }
        DbSet<Hardware> Hardwares { get; set; }
        DbSet<Cabinet> Cabinets { get; set; }
        DbSet<FlowComputer> FlowComputers { get; set; }
        DbSet<PLC> PLCs { get; set; }
        DbSet<Pressure> Pressures { get; set; }
        DbSet<Temperature> Temperatures { get; set; }
        DbSet<Flowmeter> Flowmeters { get; set; }
        DbSet<Valve> Valves { get; set; }
        DbSet<NetworkHardware> NetworkHardwares { get; set; }
        DbSet<CheckResult> CheckResults { get; set; }
        DbSet<HardwareCheck> HardwareChecks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
