using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.ContractEntities;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Infrastructure.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Infrastructure.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option, 
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService) 
            : base(option, operationalStoreOptions)
        {
            Database.EnsureCreated();
            _currentUserService = currentUserService;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FlowMeterHardware>().OwnsOne(f => f.Settings);
            builder.Entity<ValveHardware>().OwnsOne(v => v.Settings);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Modified:
                        entity.Entity.LastModified = DateTime.Now;
                        entity.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                    case EntityState.Added:
                        entity.Entity.Created = DateTime.Now;
                        entity.Entity.CreatedBy = _currentUserService.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<CabinetHardware> CabinetHardwares { get; set; }
        public DbSet<ControllerHardware> ControllerHardwares { get; set; }
        public DbSet<MeasurementHardware> Measurements { get; set; }
        public DbSet<FlowMeterHardware> FlowMeterHardwares { get; set; }
        public DbSet<ValveHardware> ValveHardwares { get; set; }
        public DbSet<NetworkHardware> NetworkHardwares { get; set; }
    }
}
