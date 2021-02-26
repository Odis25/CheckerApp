using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Entities.ContractEntities;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Entities.Identity;
using CheckerApp.Domain.Entities.SoftwareEntities;
using CheckerApp.Domain.Enums;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Infrastructure.Data
{
    public class AppDbContext : ApiAuthorizationDbContext<ApplicationUser>, IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext(DbContextOptions<AppDbContext> option,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService)
            : base(option, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "SuperUser", NormalizedName = "SuperUser".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });

            builder.Entity<Flowmeter>().OwnsOne(e => e.Settings, ms => ms.ToTable("FlowmeterSettings"));
            builder.Entity<Valve>().OwnsOne(e => e.Settings, ms => ms.ToTable("ValveSettings"));
            builder.Entity<NetworkHardware>().OwnsMany(e => e.NetworkDevices, nd => nd.ToTable("NetworkDevices"));
            builder.Entity<ARM>().OwnsMany(e => e.NetworkAdapters, na => na.ToTable("NetworkAdapters"));

            // Table-Per-Type
            builder.Entity<Hardware>().ToTable("Hardwares");
            builder.Entity<Cabinet>().ToTable("Cabinets");
            builder.Entity<FlowComputer>().ToTable("FlowComputers");
            builder.Entity<PLC>().ToTable("PLCs");
            builder.Entity<Pressure>().ToTable("Pressures");
            builder.Entity<Temperature>().ToTable("Temperatures");
            builder.Entity<Flowmeter>().ToTable("Flowmeters");
            builder.Entity<DiffPressure>().ToTable("DiffPressures");
            builder.Entity<GasAnalyzer>().ToTable("GasAnalyzers");
            builder.Entity<NetworkHardware>().ToTable("NetworkHardwares");
            builder.Entity<Valve>().ToTable("Valves");
            builder.Entity<ARM>().ToTable("ARMs");

            builder.Entity<Software>()
                .HasDiscriminator(e => e.SoftwareType)
                .HasValue<SCADA>(SoftwareType.SCADA)
                .HasValue<Software>(SoftwareType.Other);

            base.OnModelCreating(builder);
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<FlowComputer> FlowComputers { get; set; }
        public DbSet<PLC> PLCs { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Pressure> Pressures { get; set; }
        public DbSet<DiffPressure> DiffPressures { get; set; }
        public DbSet<Flowmeter> Flowmeters { get; set; }
        public DbSet<Valve> Valves { get; set; }
        public DbSet<ARM> ARMs { get; set; }
        public DbSet<NetworkHardware> NetworkHardwares { get; set; }
        public DbSet<CheckParameter> CheckParameters { get; set; }
        public DbSet<HardwareCheck> HardwareChecks { get; set; }
        public DbSet<SoftwareCheck> SoftwareChecks { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<AuditableEntity>())
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
    }
}
