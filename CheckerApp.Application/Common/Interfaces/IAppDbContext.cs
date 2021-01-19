using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Entities.ContractEntities;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Entities.SoftwareEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Contract> Contracts { get; set; }
        DbSet<Hardware> Hardwares { get; set; }
        DbSet<Software> Softwares { get; set; }
        DbSet<Cabinet> Cabinets { get; set; }
        DbSet<FlowComputer> FlowComputers { get; set; }
        DbSet<PLC> PLCs { get; set; }
        DbSet<Pressure> Pressures { get; set; }
        DbSet<Temperature> Temperatures { get; set; }
        DbSet<DiffPressure> DiffPressures { get; set; }
        DbSet<Flowmeter> Flowmeters { get; set; }
        DbSet<Valve> Valves { get; set; }
        DbSet<ARM> ARMs { get; set; }
        DbSet<NetworkHardware> NetworkHardwares { get; set; }
        DbSet<HardwareCheck> HardwareChecks { get; set; }
        DbSet<SoftwareCheck> SoftwareChecks { get; set; }
        DbSet<CheckParameter> CheckParameters { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry Update(object entity);
    }
}
