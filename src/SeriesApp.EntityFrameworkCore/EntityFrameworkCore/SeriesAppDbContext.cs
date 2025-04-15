using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using SeriesApp.Entities;

namespace SeriesApp.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SeriesAppDbContext : AbpDbContext<SeriesAppDbContext>, ITenantManagementDbContext, IIdentityDbContext
{
    // Entidades personalizadas
    public DbSet<User> AppUsers { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<TrackingList> TrackingLists { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<ApiLog> ApiLogs { get; set; }

    // DbSets requeridos por IIdentityDbContext
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // DbSets requeridos por ITenantManagementDbContext
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    public SeriesAppDbContext(DbContextOptions<SeriesAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configuraciones de los módulos ABP
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        // Configuración de entidades personalizadas
        builder.Entity<User>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Users", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Serie>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Series", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<Notification>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Notifications", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(n => n.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<TrackingList>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "TrackingLists", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(tl => tl.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
            b.HasMany(tl => tl.Series)
                .WithMany()
                .UsingEntity(j => j.ToTable(SeriesAppConsts.DbTablePrefix + "TrackingListSeries"));
        });

        builder.Entity<Rating>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "Ratings", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(r => r.Serie)
                .WithMany()
                .HasForeignKey("SerieId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<ApiLog>(b =>
        {
            b.ToTable(SeriesAppConsts.DbTablePrefix + "ApiLogs", SeriesAppConsts.DbSchema);
            b.ConfigureByConvention();
        });
    }
}