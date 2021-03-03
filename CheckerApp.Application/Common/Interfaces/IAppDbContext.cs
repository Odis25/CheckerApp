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
        DbSet<CheckParameter> CheckParameters { get; set; }

        DbSet<HardwareCheck> HardwareChecks { get; set; }
        DbSet<SoftwareCheck> SoftwareChecks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry Update(object entity);
    }
}
